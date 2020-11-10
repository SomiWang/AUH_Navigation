Shader "UnityLibrary/Patterns/ScrollingFill"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Fill("Fill", Range(0.0,1.0)) = 0.5
		_Alpha("Alpha",  Range(0.0,1.0)) = 1
		_Speed("Speed", float) = 5
	}

		SubShader
		{
			Tags { "Queue" = "Transparent" }
			LOD 100

			Pass
			{
				ZWrite On
				Blend SrcAlpha OneMinusSrcAlpha

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
				float _Fill;
				float _Speed;
				float _Alpha;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					// get scroll value
					float2 scroll = float2(0, frac(_Time.x * _Speed));

					// sample texture
					fixed4 col = tex2D(_MainTex, i.uv - scroll);

					float end = _Fill * _MainTex_ST.y;

					// discard if uv.y is below cut value
					clip(step(i.uv.y, end) - 0.1);


					if (col.a != 0)
					{

						if (i.uv.y < end * 0.5)
							col.a = i.uv.y;
						else
							col.a = (end - i.uv.y);

						col.a = col.a * _Alpha;
					}
					return col;

					// make un-animated part black
					//return col*step(i.uv.y, _Cut * _MainTex_ST.y);
				}
				ENDCG
			}
		}
}