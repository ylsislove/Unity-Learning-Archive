Shader "Unlit/002"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
            
            // POSITION SV_POSITION 语义，告诉编辑器这个变量是个什么东西
            float4 vert(float4 v:POSITION):SV_POSITION
            {
                return UnityObjectToClipPos(v);
            }

            fixed4 frag():SV_TARGET
            {
                return fixed4(1,1,1,1);    
            }

            ENDCG
        }
    }
}
