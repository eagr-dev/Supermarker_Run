Shader "Custom/SeeThrough_Strict" {
    Properties{
        _Color("Main Color", Color) = (1,1,1,1)
        _MainTex("Base (RGB)", 2D) = "white" {}

    // Propiedades del Outline (SOLO para la parte visible)
    _OutlineColor("Outline Color", Color) = (0,1,1,0.8)
    _Outline("Outline width", Range(0.0, 0.1)) = 0.005

        // Propiedades del X-Ray (SOLO para la parte oculta)
        // Ajusta el Alpha de este color para hacerlo más fantasmal
        _XRayColor("X-Ray Tint & Alpha", Color) = (1,1,1,0.4)
    }

        SubShader{
        // Renderizamos en la cola transparente para que se ordene correctamente
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }

        // ------------------------------------------------------------------
        // PASE 1: Renderizado NORMAL (Visible)
        // ------------------------------------------------------------------
        Pass {
            Name "BASE"
            Tags { "LightMode" = "ForwardBase" }
            ZWrite On      // Escribimos en el buffer de profundidad
            ZTest LEqual   // Solo dibujar si está AL FRENTE (o igual)
            Cull Back
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog
            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                UNITY_TRANSFER_FOG(o, o.pos);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

            // Iluminación básica
            float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
            float NdotL = max(0, dot(i.worldNormal, lightDir));
            col.rgb *= NdotL * _LightColor0.rgb + UNITY_LIGHTMODEL_AMBIENT.rgb;

            UNITY_APPLY_FOG(i.fogCoord, col);
            return col;
        }
        ENDCG
    }

        // ------------------------------------------------------------------
        // PASE 2: Outline (SOLO Visible)
        // ------------------------------------------------------------------
        Pass {
            Name "OUTLINE"
            Tags { "LightMode" = "Always" }
            ZWrite Off
            ZTest LEqual // Solo dibuja el borde si el objeto está visible
            Cull Front
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };

            uniform float _Outline;
            uniform float4 _OutlineColor;

            v2f vert(appdata v) {
                v2f o;
                float3 norm = normalize(v.normal);
                float3 expandedPos = v.vertex.xyz + norm * _Outline;
                o.pos = UnityObjectToClipPos(float4(expandedPos, 1));
                o.color = _OutlineColor;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                return i.color;
            }
            ENDCG
        }

            // ------------------------------------------------------------------
            // PASE 3: X-Ray (SOLO Oculto)
            // ------------------------------------------------------------------
            Pass {
                Name "XRAY"
                Tags { "LightMode" = "Always" }
                ZWrite Off

                // ESTA ES LA CLAVE:
                // Greater = Solo dibuja si la profundidad del objeto es MAYOR que lo que ya está dibujado (la pared).
                // Si el objeto está al frente, este pase FALLA y no dibuja nada.
                ZTest Greater

                Cull Back
                Blend SrcAlpha OneMinusSrcAlpha

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed4 _Color;
                uniform float4 _XRayColor;

                v2f vert(appdata v) {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    // 1. Tomamos la textura original
                    fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                // 2. Aplicamos el tinte XRay
                // Si pones el Alpha del _XRayColor en 0.3, se verá transparente a través de la pared.
                col.rgb *= _XRayColor.rgb;
                col.a *= _XRayColor.a;

                return col;
            }
            ENDCG
        }
    }
        Fallback "Diffuse"
}