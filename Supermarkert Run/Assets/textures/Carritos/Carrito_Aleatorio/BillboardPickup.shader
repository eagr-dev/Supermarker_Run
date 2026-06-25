Shader "Custom/BillboardPickup"
{
    Properties
    {
        _MainTex("Símbolo (Textura)", 2D) = "white" {}
        [HDR] _Color("Tint color", Color) = (1,1,1,1)
        _FloatSpeed("Velocidad de Flote", Float) = 2.0
        _FloatAmp("Amplitud de Flote", Float) = 0.15
        _RotSpeed("Velocidad de Giro", Float) = 120.0
    }
        SubShader
        {
            // "DisableBatching"="True" es VITAL para que cada objeto conserve su propia posición de origen
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "DisableBatching" = "True" }
            LOD 100

            Pass
            {
                Blend SrcAlpha OneMinusSrcAlpha
                ZWrite Off
                Cull Off

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed4 _Color;
                float _FloatSpeed;
                float _FloatAmp;
                float _RotSpeed;

                v2f vert(appdata v)
                {
                    v2f o;

                    // 1. ROTACIÓN: Girar los vértices en el eje Z local (giro plano tipo moneda frente a la cámara)
                    float angle = _Time.y * _RotSpeed * 0.0174532925; // Convertir grados a radianes
                    float cosA = cos(angle);
                    float sinA = sin(angle);
                    float2 rotatedVertex;
                    rotatedVertex.x = v.vertex.x * cosA - v.vertex.y * sinA;
                    rotatedVertex.y = v.vertex.x * sinA + v.vertex.y * cosA;

                    // 2. FLOTADO: Calcular el desfase vertical (Arriba/Abajo) usando una onda Seno
                    float floatOffset = sin(_Time.y * _FloatSpeed) * _FloatAmp;

                    // 3. BILLBOARD: Obtener la posición central del objeto en el mundo e ignorar su rotación nativa
                    float4 worldOrigin = mul(UNITY_MATRIX_M, float4(0, 0, 0, 1));
                    worldOrigin.y += floatOffset; // Aplicamos el flote aquí en el mundo real

                    // Convertir ese centro al espacio de la cámara (View Space)
                    float4 viewPos = mul(UNITY_MATRIX_V, worldOrigin);

                    // Recuperar la escala del objeto en el mundo para que no se deforme
                    float scaleX = length(UNITY_MATRIX_M._m00_m10_m20);
                    float scaleY = length(UNITY_MATRIX_M._m01_m11_m21);

                    // Añadir los vértices ya rotados directamente alineados con los ejes de la pantalla (Cámara)
                    viewPos.xyz += float3(rotatedVertex.x * scaleX, rotatedVertex.y * scaleY, 0);

                    // Proyección final a la pantalla
                    o.vertex = mul(UNITY_MATRIX_P, viewPos);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                    return col;
                }
                ENDCG
            }
        }
}