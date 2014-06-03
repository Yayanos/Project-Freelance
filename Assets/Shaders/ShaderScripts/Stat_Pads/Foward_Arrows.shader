Shader "Custom/Forward_Arrows"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_MidTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		_Speed ("MoveSpeed", Range(0.1, 1)) = 1
		}

	SubShader
	{
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		LOD 200
	
		CGPROGRAM
		#pragma surface surf Lambert alphatest:_Cutoff

		sampler2D _MainTex;
		sampler2D _MidTex;
		fixed4 _Color;
		half _Speed;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_MidTex;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			float2 uv = IN.uv_MainTex;
			float2 uv2 = IN.uv_MidTex;

			uv.y -= _Time.w * _Speed;
			uv2.x -= _Time.x * _Speed;
			
			fixed4 c = tex2D(_MainTex, uv);
			c *= tex2D(_MidTex, uv2);

			c *= _Color;

			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}

	Fallback "Transparent/Cutout/VertexLit"
}
