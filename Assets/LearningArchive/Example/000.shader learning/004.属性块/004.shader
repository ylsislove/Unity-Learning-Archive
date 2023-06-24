Shader "Unlit/004"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            // 只有在CGPROGRAM内再次定义一个与属性块内名字与类型相同的变量，属性块对应的变量才能起作用
            fixed4 _Color;
            
            // 名字可自定义，但有些含义 a application to vert
            struct a2v
            {
                // 用模型顶点填充v变量
                float4 vertex:POSITION;
                // 用模型的法线填充n变量
                float3 normal:NORMAL;
                // 用模型的第一套uv填充texcoord
                float4 texcoord:TEXCOORD0;
            };

            // v vert to frag
            struct v2f
            {
                // SV_POSITION语义告诉unity : pos 为裁剪空间中的位置信息
                float4 pos:SV_POSITION;
                // COLOR0 语义可以存储颜色信息
                fixed3 color:COLOR0;
            };

            v2f vert(a2v v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                // 将 [-1, 1] 转变为 [0, 1]
                o.color = v.normal * 0.5 + fixed3(0.5, 0.5, 0.5);
                return o;
            }

            fixed4 frag(v2f i):SV_TARGET
            {
                fixed3 c = i.color;
                // .xyzw  .rgba  .x  .xz
                c *= _Color.rgb;
                return fixed4(c, 1);    
            }

            ENDCG
        }
    }
}
