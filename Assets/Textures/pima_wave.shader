Shader "pima/pima_wave"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "black" {}
        _BPM ("BPM", float) = 120.0
    }
    SubShader
    {
        Tags { 
            "RenderType"="Opaque"
             }
        LOD 100

        

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BPM;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float mod(float x, float y){
                return x - y * floor(x/y);
            }
            
            fixed4 innercircle(float2 q, float in_r, float out_r, float speed, float width, fixed4 color, fixed4 col){
                float2 p = q;
                float freq = mod(_Time.y, 60.0/_BPM);
                float calc_r = min(freq*speed*_BPM/120.0, out_r-in_r) + in_r;
                float l = width / abs(length(p)-calc_r);
                return fixed4(max(color.rgb*l, col), 1.0);
            }

            fixed4 outercircle(float2 q, float in_r, float delay, float speed, float width, fixed4 color, fixed4 col){
                float2 p = q;
                float freq = mod(_Time.y + delay, 60.0/_BPM);
                float calc_r = freq*speed*_BPM/120.0 + in_r;
                float l = width / abs(length(p)-calc_r);
                return fixed4(max(color.rgb*l, col), 1.0);
            }

            fixed4 frag (v2f i) : SV_Target
            {   
                fixed4 WHITE = fixed4(1,1,1,1);
                fixed4 BLACK = fixed4(0,0,0,1);
                fixed4 col = BLACK;
                float2 p = 2.0 * i.uv - 1.0;
                // sample the texture
                col = tex2D(_MainTex, i.uv);
                col = innercircle(p, 0.2, 0.3, 1.0, 0.04, WHITE, col);
                col = outercircle(p, 0.15, -0.0, 3.0, 0.01, WHITE, col);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
