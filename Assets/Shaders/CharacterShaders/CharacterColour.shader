shader "Unlit/CharacterColor" {

	Properties{
		_MainTex("Texture", 2D) = "playerSprites_1" {}
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader{
			
		Pass{
			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct vertexToFragment {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			fixed4 _Color;
			sampler2D _MainTex;

			vertexToFragment vertexFunction(appdata IN) {
				vertexToFragment OUT;

				OUT.position = UnityObjectToClipPos(IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			fixed4 fragmentFunction(vertexToFragment IN) : SV_Target{
				fixed4 pixelColor = tex2D(_MainTex, IN.uv);

				return pixelColor * _Color;
			}
			ENDCG
		}
	}
}
