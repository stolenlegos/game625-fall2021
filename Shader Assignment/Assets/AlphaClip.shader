Shader "Demonstration/SoftAlphaClipping" {
   Properties {
       _MainTex ("Texture", 2D) = "white" {}
      _Softness("Softness", Range(0, 1)) = 0.3
   }

   SubShader {
      Tags {
         "Queue" = "Transparent"
         "RenderType" = "Transparent"
      }

       Pass {
         Cull Off
         Blend SrcAlpha OneMinusSrcAlpha
         ZWrite Off

           CGPROGRAM

           #pragma vertex vert
           #pragma fragment frag

           sampler2D _MainTex;
           float4 _MainTex_ST;
           float _Softness;


           struct vertInput {
               float4 vertex : POSITION;
               float4 texCoord : TEXCOORD0;
           };


           struct vertOutput {
               float4 tex : TEXCOORD0;
               float4 pos : SV_POSITION;
           };


           vertOutput vert (vertInput input) {
               vertOutput output;
               output.pos = UnityObjectToClipPos(input.vertex);
               output.tex = input.texCoord;
               return output;
           }


           float4 soften(float4 color) {
              clip(color - _Softness);
              return color;
           }


           float4 frag (vertOutput input) : COlOR {
            float4 col = tex2D(_MainTex, input.tex.xy);
            col = soften(col);
            return col - float4(0.1, 0.4, 0.8, 0.0);
           }


           ENDCG
       }
   }
}
