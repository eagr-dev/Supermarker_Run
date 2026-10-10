Shader "Custom/WorldCheckerboard_URP"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color Tint", Color) = (1,1,1,1)
        _Tiling("Tiling Scale", Float) = 0.5

        [Header(Light Bounce)]
        _AdditionalLightsStrength("Additional Lights Strength", Range(0, 5)) = 1
        _BounceWrap("Bounce Wrap (1 = rebote total, 0 = Lambert)", Range(0, 1)) = 1

        [Header(Debug)]
        [Toggle] _DebugBaked("DEBUG: ver solo luz horneada (magenta = sin lightmap)", Float) = 0
    }

    SubShader
    {
        Tags 
        { 
            "RenderType" = "Opaque" 
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Geometry" 
        }

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile _ LIGHTMAP_ON
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
                float4 positionOS   : POSITION;
                float3 normalOS     : NORMAL;
                float2 staticLightmapUV : TEXCOORD1;
            };

            struct Varyings
            {
                float4 positionCS   : SV_POSITION;
                float3 worldPos     : TEXCOORD0;
                float3 normalWS     : TEXCOORD1;
                float2 staticLightmapUV : TEXCOORD2;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _Color;
                float  _Tiling;
                float  _AdditionalLightsStrength;
                float  _BounceWrap;
                float  _DebugBaked;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output = (Varyings)0;

                VertexPositionInputs posInputs = GetVertexPositionInputs(input.positionOS.xyz);
                VertexNormalInputs normInputs = GetVertexNormalInputs(input.normalOS);

                output.positionCS = posInputs.positionCS;
                output.worldPos = posInputs.positionWS;
                output.normalWS = normInputs.normalWS;

                #if defined(LIGHTMAP_ON)
                    output.staticLightmapUV = input.staticLightmapUV * unity_LightmapST.xy + unity_LightmapST.zw;
                #else
                    output.staticLightmapUV = float2(0, 0);
                #endif

                return output;
            }

            // Suma el rebote de UNA luz adicional sobre el suelo.
            // _BounceWrap = 1 -> ignora el angulo (la luz "rebota" y llena el suelo por distancia/cono)
            // _BounceWrap = 0 -> Lambert normal
            void AddBounceLight(Light l, float3 N, inout half3 acc)
            {
                float lambert = saturate(dot(N, l.direction));
                float wrap    = lerp(lambert, 1.0, _BounceWrap);
                acc += l.color * (l.distanceAttenuation * l.shadowAttenuation * wrap * _AdditionalLightsStrength);
            }

            half4 frag(Varyings input) : SV_Target
            {
                float2 worldUV = input.worldPos.xz * _Tiling;
                half4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, worldUV) * _Color;

                float3 up = float3(0, 1, 0);

                // 1. Bake / Ambient
                #if defined(LIGHTMAP_ON)
                    // Lectura estandar del lightmap de URP (luz horneada: color + rebotes)
                    #if defined(UNITY_LIGHTMAP_FULL_HDR)
                        bool encodedLightmap = false;
                    #else
                        bool encodedLightmap = true;
                    #endif
                    half4 decodeInstructions = half4(LIGHTMAP_HDR_MULTIPLIER, LIGHTMAP_HDR_EXPONENT, 0.0h, 0.0h);
                    half3 bakedGI = SampleSingleLightmap(
                        TEXTURE2D_LIGHTMAP_ARGS(LIGHTMAP_NAME, LIGHTMAP_SAMPLER_NAME),
                        input.staticLightmapUV, float4(1, 1, 0, 0),
                        encodedLightmap, decodeInstructions);
                #else
                    half3 bakedGI = SampleSH(up);
                #endif

                // 2. Luz Principal (con sombras)
                half4 shadowMask = half4(1, 1, 1, 1);
                float4 shadowCoord = TransformWorldToShadowCoord(input.worldPos);
                Light mainLight = GetMainLight(shadowCoord, input.worldPos, shadowMask);
                half3 directLighting = mainLight.color * saturate(dot(up, mainLight.direction)) * mainLight.shadowAttenuation;

                // 3. Luces Adicionales (velas, spots, points) - rebote sobre el suelo
                #if defined(_ADDITIONAL_LIGHTS) || defined(_ADDITIONAL_LIGHTS_VERTEX) || defined(_FORWARD_PLUS)

                    InputData inputData = (InputData)0;
                    inputData.positionWS = input.worldPos;
                    inputData.normalWS   = up;
                    inputData.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(input.positionCS);

                    #if USE_FORWARD_PLUS || defined(_FORWARD_PLUS)
                        // Forward+: directionales adicionales
                        for (uint dirIndex = 0; dirIndex < min(URP_FP_DIRECTIONAL_LIGHTS_COUNT, MAX_VISIBLE_LIGHTS); dirIndex++)
                        {
                            Light dirLight = GetAdditionalLight(dirIndex, input.worldPos, shadowMask);
                            AddBounceLight(dirLight, up, directLighting);
                        }
                    #endif

                    uint pixelLightCount = GetAdditionalLightsCount();
                    LIGHT_LOOP_BEGIN(pixelLightCount)
                        Light addLight = GetAdditionalLight(lightIndex, input.worldPos, shadowMask);
                        AddBounceLight(addLight, up, directLighting);
                    LIGHT_LOOP_END

                #endif

                // DEBUG: muestra SOLO el lightmap.
                //  - magenta  -> este objeto NO esta usando lightmap (no es Static / Receive GI != Lightmaps)
                //  - negro    -> usa lightmap pero el bake no dejo luz en el suelo (UVs / resolucion / luces)
                //  - con color -> el bake si guardo la luz
                if (_DebugBaked > 0.5)
                {
                    #if defined(LIGHTMAP_ON)
                        return half4(bakedGI, 1);
                    #else
                        return half4(1, 0, 1, 1);
                    #endif
                }

                half3 finalRGB = texColor.rgb * (bakedGI + directLighting);

                return half4(finalRGB, texColor.a);
            }
            ENDHLSL
        }

        Pass
        {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" }
            ZWrite On
            ZTest LEqual
            ColorMask 0

            HLSLPROGRAM
            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
            ENDHLSL
        }

        // ============================================
        // META: usado por el baker de Unity (albedo para color/rebote de luz)
        // ============================================
        Pass
        {
            Name "Meta"
            Tags { "LightMode" = "Meta" }
            Cull Off

            HLSLPROGRAM
            #pragma vertex MetaVert
            #pragma fragment MetaFrag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"

            struct MetaAttributes
            {
                float4 positionOS : POSITION;
                float2 uv1        : TEXCOORD1;
                float2 uv2        : TEXCOORD2;
            };

            struct MetaVaryings
            {
                float4 positionCS : SV_POSITION;
                float3 worldPos   : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST;
                float4 _Color;
                float  _Tiling;
                float  _AdditionalLightsStrength;
                float  _BounceWrap;
                float  _DebugBaked;
            CBUFFER_END

            MetaVaryings MetaVert(MetaAttributes input)
            {
                MetaVaryings output;
                output.worldPos   = TransformObjectToWorld(input.positionOS.xyz);
                output.positionCS = MetaVertexPosition(input.positionOS, input.uv1, input.uv2,
                                                       unity_LightmapST, unity_DynamicLightmapST);
                return output;
            }

            half4 MetaFrag(MetaVaryings input) : SV_Target
            {
                float2 worldUV = input.worldPos.xz * _Tiling;
                half4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, worldUV) * _Color;

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