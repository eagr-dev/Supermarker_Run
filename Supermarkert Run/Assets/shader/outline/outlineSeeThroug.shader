Shader "Custom/SeeThrough_URP"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1)
        _MainTex("Base (RGB)", 2D) = "white" {}

        _OutlineColor("Outline Color", Color) = (0,1,1,0.8)
        _Outline("Outline width", Range(0.0, 0.1)) = 0.005

        _XRayColor("X-Ray Tint & Alpha", Color) = (1,1,1,0.4)
    }

        SubShader
        {
            Tags
            {
                "RenderPipeline" = "UniversalPipeline"
                "Queue" = "Transparent"
            }

            // ------------------------------------------------------------------
            // PASS 1: X-Ray — se dibuja PRIMERO, antes de que nadie escriba depth
            // ZTest Greater: pasa solo donde hay geometría opaca DELANTE del objeto
            // ZWrite Off:    no contamina el depth buffer
            // ------------------------------------------------------------------
            Pass
            {
                Name "XRAY"
                Tags { "LightMode" = "SRPDefaultUnlit" }
                ZWrite Off
                ZTest Greater
                Cull Back
                Blend SrcAlpha OneMinusSrcAlpha

                HLSLPROGRAM
                #pragma vertex XRayVert
                #pragma fragment XRayFrag

                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

                struct Attributes
                {
                    float4 positionOS : POSITION;
                    float2 uv         : TEXCOORD0;
                };

                struct Varyings
                {
                    float4 positionHCS : SV_POSITION;
                    float2 uv          : TEXCOORD0;
                };

                TEXTURE2D(_MainTex);
                SAMPLER(sampler_MainTex);

                CBUFFER_START(UnityPerMaterial)
                    float4 _MainTex_ST;
                    float4 _Color;
                    float4 _OutlineColor;
                    float  _Outline;
                    float4 _XRayColor;
                CBUFFER_END

                Varyings XRayVert(Attributes IN)
                {
                    Varyings OUT;
                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                    OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
                    return OUT;
                }

                half4 XRayFrag(Varyings IN) : SV_Target
                {
                    half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv) * _Color;
                    col.rgb *= _XRayColor.rgb;
                    col.a *= _XRayColor.a;
                    return col;
                }
                ENDHLSL
            }

            // ------------------------------------------------------------------
            // PASS 2: Outline — solo donde el objeto es visible
            // ------------------------------------------------------------------
            Pass
            {
                Name "OUTLINE"
                Tags { "LightMode" = "SRPDefaultUnlit" }
                ZWrite Off
                ZTest LEqual
                Cull Front
                Blend SrcAlpha OneMinusSrcAlpha

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
                    float4 color       : TEXCOORD0;
                };

                CBUFFER_START(UnityPerMaterial)
                    float4 _MainTex_ST;
                    float4 _Color;
                    float4 _OutlineColor;
                    float  _Outline;
                    float4 _XRayColor;
                CBUFFER_END

                Varyings OutlineVert(Attributes IN)
                {
                    Varyings OUT;
                    float3 normal = normalize(IN.normalOS);
                    float3 expandedPos = IN.positionOS.xyz + normal * _Outline;
                    OUT.positionHCS = TransformObjectToHClip(float4(expandedPos, 1.0));
                    OUT.color = _OutlineColor;
                    return OUT;
                }

                half4 OutlineFrag(Varyings IN) : SV_Target
                {
                    return IN.color;
                }
                ENDHLSL
            }

                    // ------------------------------------------------------------------
                    // PASS 3: Base — se dibuja AL FINAL, escribe depth y tapa el X-Ray
                    // ------------------------------------------------------------------
                    Pass
                    {
                        Name "BASE"
                        Tags { "LightMode" = "UniversalForward" }
                        ZWrite On
                        ZTest LEqual
                        Cull Back
                        Blend SrcAlpha OneMinusSrcAlpha

                        HLSLPROGRAM
                        #pragma vertex BaseVert
                        #pragma fragment BaseFrag
                        #pragma multi_compile_fog
                        #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE
                        #pragma multi_compile _ _SHADOWS_SOFT

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
                            float  fogFactor : TEXCOORD2;
                            float4 shadowCoord : TEXCOORD3;
                        };

                        TEXTURE2D(_MainTex);
                        SAMPLER(sampler_MainTex);

                        CBUFFER_START(UnityPerMaterial)
                            float4 _MainTex_ST;
                            float4 _Color;
                            float4 _OutlineColor;
                            float  _Outline;
                            float4 _XRayColor;
                        CBUFFER_END

                        Varyings BaseVert(Attributes IN)
                        {
                            Varyings OUT;
                            VertexPositionInputs posInputs = GetVertexPositionInputs(IN.positionOS.xyz);
                            VertexNormalInputs   normInputs = GetVertexNormalInputs(IN.normalOS);

                            OUT.positionHCS = posInputs.positionCS;
                            OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
                            OUT.normalWS = normInputs.normalWS;
                            OUT.fogFactor = ComputeFogFactor(posInputs.positionCS.z);
                            OUT.shadowCoord = GetShadowCoord(posInputs);
                            return OUT;
                        }

                        half4 BaseFrag(Varyings IN) : SV_Target
                        {
                            half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv) * _Color;

                            Light mainLight = GetMainLight(IN.shadowCoord);
                            float3 lightDir = normalize(mainLight.direction);
                            float NdotL = max(0, dot(normalize(IN.normalWS), lightDir));
                            half3 ambient = SampleSH(normalize(IN.normalWS));

                            col.rgb *= NdotL * mainLight.color * mainLight.shadowAttenuation + ambient;
                            col.rgb = MixFog(col.rgb, IN.fogFactor);

                            return col;
                        }
                        ENDHLSL
                    }

                    // ------------------------------------------------------------------
                    // PASS 4: Shadow Caster
                    // ------------------------------------------------------------------
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

                        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
                        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
                        #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
                        ENDHLSL
                    }

                            // ------------------------------------------------------------------
                            // PASS 5: Depth Only
                            // ------------------------------------------------------------------
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