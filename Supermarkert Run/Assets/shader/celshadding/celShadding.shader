Shader "Custom/CelShading"
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
            Tags { "RenderType" = "Opaque" "LightMode" = "ForwardBase" }
            LOD 200

            // ============================================
            // PASS 1: Outline (se dibuja primero)
            // ============================================
            Pass
            {
                Name "Outline"
                Cull Front

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                };

                struct v2f
                {
                    float4 pos : SV_POSITION;
                };

                float _OutlineWidth;
                float4 _OutlineColor;

                v2f vert(appdata v)
                {
                    v2f o;

                    // Expandir vértices en dirección de la normal
                    float3 normal = normalize(v.normal);
                    float3 outlinePos = v.vertex.xyz + normal * _OutlineWidth;

                    o.pos = UnityObjectToClipPos(float4(outlinePos, 1.0));
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    return _OutlineColor;
                }
                ENDCG
            }

            // ============================================
            // PASS 2: Cel Shading Principal
            // ============================================
            Pass
            {
                Name "CelShading"
                Cull Back

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fwdbase
                #include "UnityCG.cginc"
                #include "Lighting.cginc"
                #include "AutoLight.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                    float3 worldNormal : TEXCOORD1;
                    float3 worldPos : TEXCOORD2;
                    SHADOW_COORDS(3)
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color;
                float4 _ShadowColor;
                float _ShadowThreshold;
                float _ShadowSmoothness;
                float4 _RimColor;
                float _RimAmount;
                float _RimThreshold;
                float4 _SpecularColor;
                float _Glossiness;
                float _SpecularStrength;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    o.worldNormal = UnityObjectToWorldNormal(v.normal);
                    o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                    TRANSFER_SHADOW(o);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // Textura base
                    float4 texColor = tex2D(_MainTex, i.uv) * _Color;

                    // Normalizar vectores
                    float3 normal = normalize(i.worldNormal);
                    float3 viewDir = normalize(_WorldSpaceCameraPos - i.worldPos);
                    float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

                    // ===== CEL SHADING: Iluminación por bandas =====
                    float NdotL = dot(normal, lightDir);

                    // Crear bandas de iluminación
                    float lightIntensity = smoothstep(_ShadowThreshold - _ShadowSmoothness,
                                                      _ShadowThreshold + _ShadowSmoothness,
                                                      NdotL);

                    // Sombras de Unity
                    float shadow = SHADOW_ATTENUATION(i);
                    lightIntensity *= shadow;

                    // Color final con sombras
                    float4 lightColor = lerp(_ShadowColor, float4(1,1,1,1), lightIntensity);

                    // ===== RIM LIGHTING (luz de borde) =====
                    float rimDot = 1 - dot(viewDir, normal);
                    float rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimDot);
                    rimIntensity *= pow(NdotL, _RimThreshold);
                    float4 rim = rimIntensity * _RimColor;

                    // ===== SPECULAR (brillo) =====
                    float3 halfVector = normalize(lightDir + viewDir);
                    float NdotH = dot(normal, halfVector);
                    float specularIntensity = pow(max(NdotH, 0.0), _Glossiness * _Glossiness);

                    // Convertir specular a bandas
                    float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
                    float4 specular = specularIntensitySmooth * _SpecularColor * _SpecularStrength;

                    // ===== COMBINAR TODO =====
                    float4 finalColor = texColor * lightColor * _LightColor0;
                    finalColor += rim;
                    finalColor += specular;

                    return finalColor;
                }
                ENDCG
            }

                    // Sombras
                    UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
        }

            FallBack "Diffuse"
}