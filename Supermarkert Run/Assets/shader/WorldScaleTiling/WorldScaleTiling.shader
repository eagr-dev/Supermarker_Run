Shader "Custom/WorldCheckerboard"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Tiling("Tiling Scale", Float) = 0.5
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                };

                struct v2f
                {
                    float4 vertex : SV_POSITION;
                    float3 worldPos : TEXCOORD0;
                };

                sampler2D _MainTex;
                float _Tiling;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    // Convertimos la posición local a posición en el mundo
                    o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // Mapeamos los ejes X y Z del mundo como coordenadas UV
                    float2 worldUV = i.worldPos.xz * _Tiling;

                    // Leemos la textura con las nuevas coordenadas
                    fixed4 col = tex2D(_MainTex, worldUV);
                    return col;
                }
                ENDCG
            }
        }
}