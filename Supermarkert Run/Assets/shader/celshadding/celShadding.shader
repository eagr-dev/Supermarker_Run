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

                #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE
                #pragma multi_compile _ _SHADOWS_SOFT
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

                half4 CelFrag(Varyings IN) : SV_Target
                {
                    // Textura base
                    half4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv) * _Color;

                    // Vectores
                    float3 normalWS = normalize(IN.normalWS);
                    float3 viewDirWS = normalize(GetWorldSpaceViewDir(IN.positionWS));

                    // Luz principal URP
                    Light mainLight = GetMainLight(IN.shadowCoord);
                    float3 lightDir = normalize(mainLight.direction);
                    float  shadow = mainLight.shadowAttenuation;

                    // CEL SHADING
                    float NdotL = dot(normalWS, lightDir);
                    float lightIntensity = smoothstep(
                        _ShadowThreshold - _ShadowSmoothness,
                        _ShadowThreshold + _ShadowSmoothness,
                        NdotL
                    );
                    lightIntensity *= shadow;
                    half4 lightColor = lerp(_ShadowColor, half4(1,1,1,1), lightIntensity);

                    // RIM LIGHT
                    float rimDot = 1.0 - dot(viewDirWS, normalWS);
                    float rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimDot);
                    rimIntensity *= pow(max(NdotL, 0.0), _RimThreshold);
                    half4 rim = rimIntensity * _RimColor;

                    // SPECULAR
                    float3 halfVector = normalize(lightDir + viewDirWS);
                    float  NdotH = dot(normalWS, halfVector);
                    float  specularIntensity = pow(max(NdotH, 0.0), _Glossiness * _Glossiness);
                    float  specularBand = smoothstep(0.005, 0.01, specularIntensity);
                    half4  specular = specularBand * _SpecularColor * _SpecularStrength;

                    // Color de la luz
                    half4 mainLightColor = half4(mainLight.color, 1.0);

                    // Combinar
                    half4 finalColor = texColor * lightColor * mainLightColor;
                    finalColor += rim;
                    finalColor += specular;
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