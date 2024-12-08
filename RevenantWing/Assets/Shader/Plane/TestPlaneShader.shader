Shader "Cunstom/Test/TestPlaneShader"
{
    Properties
    {
        _MainColor ("MainColor",Color) = (1,1,1,1)

        _SubColor ("SubColor",Color) = (1,1,1,1)

        _Divide ("Divide",int) = 1
    }
    SubShader
    {

        Pass
        {
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 _MainColor;

            float4 _SubColor;

            int _Divide;

            fixed4 frag (v2f i) : SV_Target
            {
                float2 st = floor(i.uv * _Divide);

                float stepCheck = step(1 , fmod(st.x + st.y , 2));

                if(stepCheck == 0)
                {
                    return float4(_MainColor.x,_MainColor.y,_MainColor.z,1);
                }
                else if(stepCheck == 1)
                {
                    return float4(_SubColor.x,_SubColor.y,_SubColor.z,1);
                }
                else return float4(0,0,0,0);
            }
            ENDCG
        }
    }
}
