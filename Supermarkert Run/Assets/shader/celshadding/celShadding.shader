Shader "Custom/CelShading_URP"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)

        [Header(Cel Shading)]
        _ShadowColor("Shadow Color", Color) = (0.3, 0.3, 0.3, 1)
        _ShadowThreshold("Shadow Threshold", Range(0, 1)) = 0.5
        _ShadowSmoothness("Shadow Smoothness", Range(0, 1)) = 0.05

        [Header(Rim Light)]
        _RimColor("Rim Color", Color) = (1, 1, 1, 1)
        _RimAmount("Rim Amount", Range(0, 1)) = 0.7
        _RimThreshold("Rim Threshold", Range(0, 1)) = 0.1

        [Header(Specular)]
        _SpecularColor("Specular Color", Color) = (1, 1, 1, 1)
        _Glossiness("Glossiness", Range(1, 100)) = 32
        _SpecularStrength("Specular Strength", Range(0, 1)) = 0.5

        [Header(Lights)]
        _AdditionalLightsStrength("Additional Lights Strength", Range(0, 3)) = 1
        _AmbientInfluence("Ambient Influence", Range(0, 1)) = 0

        [Header(Outline)]
        _OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth("Outline Width", Range(0, 0.1)) = 0.005
    }

        SubShader
        {
            Tags
            {
                "RenderType" = "Opaque"
                "RenderPipeline" = "UniversalPipeline"
                "Queue" = "Geometry"
            }

            // ============================================
            // PASS 1: Outline
            // ============================================
            Pass
            {
                Name "Outline"
                Tags { "LightMode" = "SRPDefaultUnlit" }
                Cull Front

                HLSLPROGRAM
                #pragma vertex OutlineVert
                #pragma fragment OutlineFrag

                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

                struct Attributes
                {
                    float4 positionOS : POSITION;
                    float3 normalOS   : NORMAL;
                };

                struct Varyings
                {
                    float4 positionHCS : SV_POSITION;
                };

                CBUFFER_START(UnityPerMaterial)
                    float4 _MainTex_ST;
                    float4 _Color;
                    float4 _ShadowColor;
                    float  _ShadowThreshold;
                    float  _ShadowSmoothness;
                    float4 _RimColor;
                    float  _RimAmount;
                    float  _RimThreshold;
                    float4 _SpecularColor;
                    float  _Glossiness;
                    float  _SpecularStrength;
                    float  _AdditionalLightsStrength;
                    float  _AmbientInfluence;
                    float  _OutlineWidth;
                    float4 _OutlineColor;
                CBUFFER_END

                Varyings OutlineVert(Attributes IN)
                {
                    Varyings OUT;
                    float3 normal = normalize(IN.normalOS);
                    float3 outlinePosOS = IN.positionOS.xyz + normal * _OutlineWidth;
                    OUT.positionHCS = TransformObjectToHClip(float4(outlinePosOS, 1.0));
                    return OUT;
                }

                half4 OutlineFrag(Varyings IN) : SV_Target
                {
                    return _OutlineColor;
                }
                ENDHLSL
            }

            // ============================================
            // PASS 2: Cel Shading Principal
            // ============================================
            Pass
            {
                Name "CelShading"
                Tags { "LightMode" = "UniversalForward" }
                Cull Back

                HLSLPROGRAM
                #pragma vertex CelVert
                #pragma fragment CelFrag

                #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
                #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
                #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
                #pragma multi_compile_fragment _ _SHADOWS_SOFT
                #pragma multi_compile _ _FORWARD_PLUS
                #pragma multi_compile_fog

                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

                struct Attributes
                {
                    float4 positionOS : POSITION;
                    float3 normalOS   : NORMAL;
                    float2 uv         : TEXCOORD0;
                };

                struct Varyings
                {
                    float4 positionHCS : SV_POSITION;
                    float2 uv          : TEXCOORD0;
                    float3 normalWS    : TEXCOORD1;
                    float3 positionWS  : TEXCOORD2;
                    float4 shadowCoord : TEXCOORD3;
                };

                TEXTURE2D(_MainTex);
                SAMPLER(sampler_MainTex);

                CBUFFER_START(UnityPerMaterial)
                    float4 _MainTex_ST;
                    float4 _Color;
                    float4 _ShadowColor;
                    float  _ShadowThreshold;
                    float  _ShadowSmoothness;
                    float4 _RimColor;
                    float  _RimAmount;
                    float  _RimThreshold;
                    float4 _SpecularColor;
                    float  _Glossiness;
                    float  _SpecularStrength;
                    float  _AdditionalLightsStrength;
                    float  _AmbientInfluence;
                    float  _OutlineWidth;
                    float4 _OutlineColor;
                CBUFFER_END

                Varyings CelVert(Attributes IN)
                {
                    Varyings OUT;

                    VertexPositionInputs posInputs = GetVertexPositionInputs(IN.positionOS.xyz);
                    VertexNormalInputs   normInputs = GetVertexNormalInputs(IN.normalOS);

                    OUT.positionHCS = posInputs.positionCS;
                    OUT.positionWS = posInputs.positionWS;
                    OUT.normalWS = normInputs.normalWS;
                    OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
                    OUT.shadowCoord = GetShadowCoord(posInputs);

                    return OUT;
                }

                // Acumula la contribución cel de UNA luz (principal o adicional)
                void AccumulateCelLight(Light light, float3 normalWS, float3 viewDirWS, float rimMask,
                                        float strength,
                                        inout float3 litAcc, inout float3 specAcc, inout float3 rimAcc)
                {
                    float  atten    = light.distanceAttenuation * light.shadowAttenuation;
                    float3 radiance = light.color * atten * strength;

                    float NdotL = dot(normalWS, light.direction);

                    // Banda cel
                    float band = smoothstep(_ShadowThreshold - _ShadowSmoothness,
                                            _ShadowThreshold + _ShadowSmoothness,
                                            NdotL);
                    litAcc += radiance * band;

                    // Rim (solo donde llega luz)
                    rimAcc += rimMask * pow(max(NdotL, 0.0), _RimThreshold) * radiance;

                    // Specular cel
                    float3 halfVector = normalize(light.direction + viewDirWS);
                    float  NdotH = dot(normalWS, halfVector);
                    float  specularIntensity = pow(max(NdotH, 0.0), _Glossiness * _Glossiness);
                    float  specularBand = smoothstep(0.005, 0.01, specularIntensity);
                    specAcc += specularBand * radiance;
                }

                half4 CelFrag(Varyings IN) : SV_Target
                {
                    // Textura base
                    half4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv) * _Color;

                    // Vectores
                    float3 normalWS  = normalize(IN.normalWS);
                    float3 viewDirWS = normalize(GetWorldSpaceViewDir(IN.positionWS));

                    float rimDot  = 1.0 - saturate(dot(viewDirWS, normalWS));
                    float rimMask = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimDot);

                    float3 litAcc  = 0;
                    float3 specAcc = 0;
                    float3 rimAcc  = 0;

                    // ---------- Luz principal ----------
                    float4 shadowCoord = TransformWorldToShadowCoord(IN.positionWS);
                    half4  shadowMask  = half4(1, 1, 1, 1);
                    Light  mainLight   = GetMainLight(shadowCoord, IN.positionWS, shadowMask);
                    AccumulateCelLight(mainLight, normalWS, viewDirWS, rimMask, 1.0,
                                       litAcc, specAcc, rimAcc);

                    // ---------- Luces adicionales (point / spot / directionales extra) ----------
                    #if defined(_ADDITIONAL_LIGHTS) || defined(_ADDITIONAL_LIGHTS_VERTEX) || defined(_FORWARD_PLUS)

                        InputData inputData = (InputData)0;
                        inputData.positionWS = IN.positionWS;
                        inputData.normalWS   = normalWS;
                        inputData.viewDirectionWS = viewDirWS;
                        inputData.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(IN.positionHCS);

                        #if USE_FORWARD_PLUS || defined(_FORWARD_PLUS)
                            // Forward+: las directionales adicionales se procesan aparte
                            for (uint dirIndex = 0; dirIndex < min(URP_FP_DIRECTIONAL_LIGHTS_COUNT, MAX_VISIBLE_LIGHTS); dirIndex++)
                            {
                                Light dirLight = GetAdditionalLight(dirIndex, IN.positionWS, shadowMask);
                                AccumulateCelLight(dirLight, normalWS, viewDirWS, rimMask,
                                                   _AdditionalLightsStrength, litAcc, specAcc, rimAcc);
                            }
                        #endif

                        uint pixelLightCount = GetAdditionalLightsCount();
                        LIGHT_LOOP_BEGIN(pixelLightCount)
                            Light addLight = GetAdditionalLight(lightIndex, IN.positionWS, shadowMask);
                            AccumulateCelLight(addLight, normalWS, viewDirWS, rimMask,
                                               _AdditionalLightsStrength, litAcc, specAcc, rimAcc);
                        LIGHT_LOOP_END

                    #endif

                    // ---------- Combinar ----------
                    float3 ambient = lerp(float3(1, 1, 1), SampleSH(normalWS), _AmbientInfluence);
                    float3 shadowTerm = _ShadowColor.rgb * ambient;

                    // Zona oscura = ShadowColor; zona iluminada = color de las luces
                    float3 diffuse = shadowTerm + litAcc * (1.0 - shadowTerm);

                    half4 finalColor;
                    finalColor.rgb = texColor.rgb * diffuse;
                    finalColor.rgb += rimAcc * _RimColor.rgb;
                    finalColor.rgb += specAcc * _SpecularColor.rgb * _SpecularStrength;
                    finalColor.a = texColor.a;

                    return finalColor;
                }
                ENDHLSL
            }

                    // ============================================
                    // PASS 3: Shadow Caster
                    // ============================================
                    Pass
                    {
                        Name "ShadowCaster"
                        Tags { "LightMode" = "ShadowCaster" }
                        ZWrite On
                        ZTest LEqual
                        ColorMask 0
                        Cull Back

                        HLSLPROGRAM
                        #pragma vertex ShadowPassVertex
                        #pragma fragment ShadowPassFragment
                        #pragma multi_compile_shadowcaster

                        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
                        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
                        #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
                        ENDHLSL
                    }

                    // ============================================
                    // PASS 4: Depth Only
                    // ============================================
                    Pass
                    {
                        Name "DepthOnly"
                        Tags { "LightMode" = "DepthOnly" }
                        ZWrite On
                        ColorMask R
                        Cull Back

                        HLSLPROGRAM
                        #pragma vertex DepthOnlyVertex
                        #pragma fragment DepthOnlyFragment

                        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
                        #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"
                        ENDHLSL
                    }
        }

            FallBack "Universal Render Pipeline/Lit"
}