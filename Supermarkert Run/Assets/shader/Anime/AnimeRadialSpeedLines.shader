Shader "Anime/RadialSpeedLinesScreen"
{
    Properties
    {
        [HideInInspector] _MainTex("Texture", 2D) = "white" {}
        _Color("Line Color", Color) = (1,1,1,1)
        _Intensity("Intensity (0 to 1)", Range(0.0, 1.0)) = 0.0
        _LineCount("Line Count", Float) = 50.0
        _LineSize("Base Line Size", Range(0.001, 0.05)) = 0.01
        _FlickerSpeed("Flicker Speed", Float) = 20.0
        _MinRadius("Center Clearance Radius", Range(0.0, 0.8)) = 0.25
        _MaxRadius("Outer Edge Radius", Range(0.5, 1.5)) = 0.95
    }
        SubShader
        {
            Tags
            {
                "RenderType" = "Transparent"
                "Queue" = "Overlay"
                "IgnoreProjector" = "True"
                "CanScaleWithCanvas" = "True"
            }
            LOD 100

            Pass
            {
                Blend SrcAlpha OneMinusSrcAlpha
                Cull Off
                ZWrite Off
                ZTest Always

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                    float4 color : COLOR;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                    float4 color : COLOR;
                };

                sampler2D _MainTex;
                float4 _Color;
                float _Intensity;
                float _LineCount;
                float _LineSize;
                float _FlickerSpeed;
                float _MinRadius;
                float _MaxRadius;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    o.color = v.color;
                    return o;
                }

                float hash(float n) { return frac(sin(n) * 43758.5453123); }

                fixed4 frag(v2f i) : SV_Target
                {
                    if (_Intensity <= 0.001) return fixed4(0, 0, 0, 0);

                    float aspect = _ScreenParams.x / _ScreenParams.y;
                    float2 uv = (i.uv - 0.5) * float2(aspect, 1.0);

                    float radius = length(uv);
                    float angle = atan2(uv.y, uv.x);

                    float normalized_angle = (angle + UNITY_PI) / (2.0 * UNITY_PI);
                    float sector = floor(normalized_angle * _LineCount);
                    float rnd = hash(sector);

                    float currentFlickerSpeed = _FlickerSpeed * lerp(0.5, 2.0, _Intensity);
                    float timeStep = floor(_Time.y * currentFlickerSpeed);
                    float flickerNoise = hash(sector + timeStep);

                    float lineThreshold = 1.0 - (_Intensity * 0.85);
                    float isLineActive = step(lineThreshold, rnd);

                    float dynamicLineSize = _LineSize * lerp(0.5, 1.8, _Intensity) * (0.8 + 0.4 * flickerNoise);

                    float line_pattern = abs(cos(angle * _LineCount * 0.5 * UNITY_PI));
                    float lineShape = step(1.0 - dynamicLineSize, line_pattern);

                    float currentMinRadius = lerp(_MinRadius + 0.15, _MinRadius, _Intensity);
                    float innerMask = smoothstep(currentMinRadius, currentMinRadius + 0.08, radius);
                    float outerMask = 1.0 - smoothstep(_MaxRadius - 0.1, _MaxRadius, radius);
                    float radialMask = innerMask * outerMask;

                    float finalAlpha = lineShape * isLineActive * radialMask * flickerNoise * _Intensity;
                    fixed4 col = _Color * i.color;
                    col.a *= finalAlpha;

                    return col;
                }
                ENDCG
            }
        }
}