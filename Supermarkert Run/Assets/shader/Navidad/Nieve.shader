Shader "Custom/URP_Snow_CelShading"
{
    Properties
    {
        [Header(Base)]
        _MainTex("Base Texture", 2D) = "white" {}
        _BaseColor("Base Color Tint", Color) = (1,1,1,1)

        [Header(Snow)]
        _SnowColor("Snow Color", Color) = (1,1,1,1)
        _SnowShadowColor("Snow Shadow Color", Color) = (0.65, 0.75, 0.95, 1)
        _SnowCutoff("Snow Angle Cutoff", Range(0.0, 1.0)) = 0.707
        _SnowBlend("Snow Blend Smoothness", Range(0.01, 0.5)) = 0.1
        _SnowMinHeight("Altura Mínima Nieve", Float) = 0.0
        _SnowMaxHeight("Altura Máxima Nieve", Float) = 5.0
        _NoiseScale("Snow Noise Scale", Float) = 10.0
        _NoiseAmount("Snow Noise Intensity", Range(0.0, 0.5)) = 0.2

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
        _BakedLightsStrength("Baked Lights Strength", Range(0, 3)) = 1
        [IntRange] _BakedCelSteps("Baked Cel Steps (0 = smooth)", Range(0, 8)) = 0

        [Header(Outline)]
        _OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth("Outline Width", Range(0, 0.1)) = 0.005

        [Header(Debug)]
        [Toggle] _DebugBaked("DEBUG: ver solo luz horneada (cian = sin lightmap)", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry"
        }

        // ============================================================
        // Código compartido por TODOS los passes.
        // Un único CBUFFER idéntico en cada pass = compatible con SRP Batcher.
        // ============================================================
        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

        CBUFFER_START(UnityPerMaterial)
            float4 _MainTex_ST;
            float4 _BaseColor;

            // Nieve
            float4 _SnowColor;
            float4 _SnowShadowColor;
            float  _SnowCutoff;
            float  _SnowBlend;
            float  _SnowMinHeight;
            float  _SnowMaxHeight;
            float  _NoiseScale;
            float  _NoiseAmount;

            // Cel
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
            float  _BakedLightsStrength;
            float  _BakedCelSteps;
            float  _OutlineWidth;
            float4 _OutlineColor;
            float  _DebugBaked;
        CBUFFER_END

        float SnowRandom(float3 p)
        {
            return frac(sin(dot(p, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
        }

        float SnowNoise(float3 p)
        {
            float3 i = floor(p);
            float3 f = frac(p);
            f = f * f * (3.0 - 2.0 * f);
            float mix1 = lerp(lerp(SnowRandom(i + float3(0,0,0)), SnowRandom(i + float3(1,0,0)), f.x),
                              lerp(SnowRandom(i + float3(0,1,0)), SnowRandom(i + float3(1,1,0)), f.x), f.y);
            float mix2 = lerp(lerp(SnowRandom(i + float3(0,0,1)), SnowRandom(i + float3(1,0,1)), f.x),
                              lerp(SnowRandom(i + float3(0,1,1)), SnowRandom(i + float3(1,1,1)), f.x), f.y);
            return lerp(mix1, mix2, f.z);
        }

        // Factor de nieve 0..1 (ángulo de la normal + altura en el mundo + ruido)
        float ComputeSnowFactor(float3 normalWS, float3 positionWS)
        {
            float snowDot = dot(normalWS, float3(0.0, 1.0, 0.0));

            float noiseVal = SnowNoise(positionWS * _NoiseScale) * _NoiseAmount;
            float adjustedCutoff = _SnowCutoff + noiseVal;
            float angleFactor = smoothstep(adjustedCutoff - _SnowBlend, adjustedCutoff + _SnowBlend, snowDot);

            float heightRange = max(_SnowMaxHeight - _SnowMinHeight, 1e-4);
            float heightFactor = saturate((positionWS.y - _SnowMinHeight) / heightRange);

            float snowFactor = angleFactor * heightFactor;

            // Seguridad para evitar caras hacia abajo
            if (snowDot < 0.2) snowFactor = 0.0;

            return snowFactor;
        }
        ENDHLSL

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

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
            };

            Varyings OutlineVert(Attributes IN)
            {
                Varyings OUT;
                float3 normal = normalize(IN.normalOS);
                float3 outlinePosOS = IN.positionOS.xyz + normal * _OutlineWidth;
                OUT.positionHCS = TransformObjectToHClip(outlinePosOS);
                return OUT;
            }

            half4 OutlineFrag(Varyings IN) : SV_Target
            {
                return _OutlineColor;
            }
            ENDHLSL
        }

        // ============================================
        // PASS 2: Nieve + Cel Shading
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
            #pragma multi_compile _ _FORWARD_PLUS _CLUSTER_LIGHT_LOOP
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
                float2 uv         : TEXCOORD0;
                float2 staticLightmapUV : TEXCOORD1;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv          : TEXCOORD0;
                float3 normalWS    : TEXCOORD1;
                float3 positionWS  : TEXCOORD2;
                float4 shadowCoord : TEXCOORD3;
                float2 lightmapUV  : TEXCOORD4;
            };

            Varyings CelVert(Attributes IN)
            {
                Varyings OUT;

                VertexPositionInputs posInputs  = GetVertexPositionInputs(IN.positionOS.xyz);
                VertexNormalInputs   normInputs = GetVertexNormalInputs(IN.normalOS);

                OUT.positionHCS = posInputs.positionCS;
                OUT.positionWS  = posInputs.positionWS;
                OUT.normalWS    = normInputs.normalWS;
                OUT.uv          = TRANSFORM_TEX(IN.uv, _MainTex);
                OUT.shadowCoord = GetShadowCoord(posInputs);

                #if defined(LIGHTMAP_ON)
                    OUT.lightmapUV = IN.staticLightmapUV * unity_LightmapST.xy + unity_LightmapST.zw;
                #else
                    OUT.lightmapUV = float2(0, 0);
                #endif

                return OUT;
            }

            // Acumula la contribucion cel de UNA luz (principal o adicional)
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
                float3 normalWS  = normalize(IN.normalWS);
                float3 viewDirWS = normalize(GetWorldSpaceViewDir(IN.positionWS));

                // ---------- Albedo: textura base mezclada con nieve ----------
                half4 baseTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv) * _BaseColor;
                float snowFactor = ComputeSnowFactor(normalWS, IN.positionWS);
                half4 texColor = lerp(baseTex, _SnowColor, snowFactor);

                float rimDot  = 1.0 - saturate(dot(viewDirWS, normalWS));
                float rimMask = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimDot);

                float3 litAcc  = 0;
                float3 specAcc = 0;
                float3 rimAcc  = 0;

                // ---------- Luz principal ----------
                float4 shadowCoord = TransformWorldToShadowCoord(IN.positionWS);
                half4  shadowMask  = SAMPLE_SHADOWMASK(IN.lightmapUV);
                Light  mainLight   = GetMainLight(shadowCoord, IN.positionWS, shadowMask);
                AccumulateCelLight(mainLight, normalWS, viewDirWS, rimMask, 1.0,
                                   litAcc, specAcc, rimAcc);

                // ---------- Luces adicionales (point / spot / directionales extra) ----------
                #if defined(_ADDITIONAL_LIGHTS) || defined(_ADDITIONAL_LIGHTS_VERTEX) || defined(_FORWARD_PLUS) || defined(_CLUSTER_LIGHT_LOOP)

                    InputData inputData = (InputData)0;
                    inputData.positionWS = IN.positionWS;
                    inputData.normalWS   = normalWS;
                    inputData.viewDirectionWS = viewDirWS;
                    inputData.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(IN.positionHCS);

                    #if USE_FORWARD_PLUS || USE_CLUSTER_LIGHT_LOOP || defined(_FORWARD_PLUS) || defined(_CLUSTER_LIGHT_LOOP)
                        // Forward+ / Cluster: las directionales adicionales se procesan aparte
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

                // ---------- Luz horneada (lightmap) ----------
                #if defined(LIGHTMAP_ON)
                    float3 bakedGI = SampleLightmap(IN.lightmapUV, 0, normalWS);

                    // Cel opcional: cuantiza la luminosidad horneada en escalones
                    if (_BakedCelSteps > 0.5)
                    {
                        float lum = max(dot(bakedGI, float3(0.2126, 0.7152, 0.0722)), 1e-4);
                        float q   = floor(lum * _BakedCelSteps + 0.5) / _BakedCelSteps;
                        bakedGI  *= q / lum;
                    }
                    litAcc += bakedGI * _BakedLightsStrength;
                #endif

                // ---------- DEBUG: ver solo lightmap ----------
                if (_DebugBaked > 0.5)
                {
                    #if defined(LIGHTMAP_ON)
                        return half4(bakedGI, 1);
                    #else
                        return half4(0, 1, 1, 1);
                    #endif
                }

                // ---------- Combinar ----------
                #if defined(LIGHTMAP_ON)
                    float3 ambient = float3(1, 1, 1);   // el lightmap ya incluye la luz indirecta
                #else
                    float3 ambient = lerp(float3(1, 1, 1), SampleSH(normalWS), _AmbientInfluence);
                #endif

                // La nieve usa su propio color de sombra (p.ej. azulado)
                float3 shadowColor = lerp(_ShadowColor.rgb, _SnowShadowColor.rgb, snowFactor);
                float3 shadowTerm  = shadowColor * ambient;

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
        // (propio, para compartir el mismo CBUFFER y mantener SRP Batcher)
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
            #pragma vertex ShadowVert
            #pragma fragment ShadowFrag
            #pragma multi_compile_vertex _ _CASTING_PUNCTUAL_LIGHT_SHADOW

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Shadows.hlsl"

            float3 _LightDirection;
            float3 _LightPosition;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
            };

            Varyings ShadowVert(Attributes IN)
            {
                Varyings OUT;
                float3 positionWS = TransformObjectToWorld(IN.positionOS.xyz);
                float3 normalWS   = TransformObjectToWorldNormal(IN.normalOS);

                #if _CASTING_PUNCTUAL_LIGHT_SHADOW
                    float3 lightDirectionWS = normalize(_LightPosition - positionWS);
                #else
                    float3 lightDirectionWS = _LightDirection;
                #endif

                float4 positionCS = TransformWorldToHClip(ApplyShadowBias(positionWS, normalWS, lightDirectionWS));
                positionCS = ApplyShadowClamping(positionCS);
                OUT.positionCS = positionCS;
                return OUT;
            }

            half4 ShadowFrag(Varyings IN) : SV_Target
            {
                return 0;
            }
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
            #pragma vertex DepthVert
            #pragma fragment DepthFrag

            struct Attributes
            {
                float4 positionOS : POSITION;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
            };

            Varyings DepthVert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                return OUT;
            }

            half DepthFrag(Varyings IN) : SV_Target
            {
                return IN.positionCS.z;
            }
            ENDHLSL
        }

        // ============================================
        // PASS 5: Depth Normals (SSAO, efectos que usan normales)
        // ============================================
        Pass
        {
            Name "DepthNormals"
            Tags { "LightMode" = "DepthNormals" }
            ZWrite On
            Cull Back

            HLSLPROGRAM
            #pragma vertex DepthNormalsVert
            #pragma fragment DepthNormalsFrag
            #pragma multi_compile_fragment _ _GBUFFER_NORMALS_OCT

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 normalWS   : TEXCOORD0;
            };

            Varyings DepthNormalsVert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.normalWS   = TransformObjectToWorldNormal(IN.normalOS);
                return OUT;
            }

            half4 DepthNormalsFrag(Varyings IN) : SV_Target
            {
                float3 normalWS = normalize(IN.normalWS);
                #if defined(_GBUFFER_NORMALS_OCT)
                    float2 octNormalWS = PackNormalOctQuadEncode(normalWS);
                    float2 remapped    = saturate(octNormalWS * 0.5 + 0.5);
                    half3  packed      = PackFloat2To888(remapped);
                    return half4(packed, 0.0);
                #else
                    return half4(normalWS, 0.0);
                #endif
            }
            ENDHLSL
        }

        // ============================================
        // META: usado por el baker de Unity
        // Incluye la nieve en el albedo para que el rebote de luz
        // horneada la tome en cuenta (objetos estáticos).
        // ============================================
        Pass
        {
            Name "Meta"
            Tags { "LightMode" = "Meta" }
            Cull Off

            HLSLPROGRAM
            #pragma vertex MetaVert
            #pragma fragment MetaFrag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"

            struct MetaAttributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
                float2 uv0        : TEXCOORD0;
                float2 uv1        : TEXCOORD1;
                float2 uv2        : TEXCOORD2;
            };

            struct MetaVaryings
            {
                float4 positionCS : SV_POSITION;
                float2 uv         : TEXCOORD0;
                float3 positionWS : TEXCOORD1;
                float3 normalWS   : TEXCOORD2;
            };

            MetaVaryings MetaVert(MetaAttributes input)
            {
                MetaVaryings output;
                output.positionCS = MetaVertexPosition(input.positionOS, input.uv1, input.uv2,
                                                       unity_LightmapST, unity_DynamicLightmapST);
                output.uv         = TRANSFORM_TEX(input.uv0, _MainTex);
                output.positionWS = TransformObjectToWorld(input.positionOS.xyz);
                output.normalWS   = TransformObjectToWorldNormal(input.normalOS);
                return output;
            }

            half4 MetaFrag(MetaVaryings input) : SV_Target
            {
                half4 baseTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv) * _BaseColor;
                float snowFactor = ComputeSnowFactor(normalize(input.normalWS), input.positionWS);
                half4 texColor = lerp(baseTex, _SnowColor, snowFactor);

                MetaInput metaInput = (MetaInput)0;
                metaInput.Albedo   = texColor.rgb;
                metaInput.Emission = 0;
                return MetaFragment(metaInput);
            }
            ENDHLSL
        }
    }

    FallBack "Universal Render Pipeline/Lit"
}