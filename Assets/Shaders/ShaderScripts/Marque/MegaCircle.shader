Shader "Custom/MegaCircle"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Radius ("Radius", Range(0, 0.5)) = 0.25
		_CenterX ("Center", Range(0, 1)) = 0.5
		_CenterY ("Center", Range(0, 1)) = 0.5
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		half _Radius;
		half _CenterX;
		half _CenterY;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half x = IN.uv_MainTex.x - _CenterX;
			half y = IN.uv_MainTex.y - _CenterY;
			
			half mag = sqrt((x * x) + (y * y));
			
			if (mag > _Radius)
				c = (c.r + c.g + c.b) / 3;
			else
			{
				c.r = abs(c.r - 1);
				c.g = abs(c.g - 1);
				c.b = abs(c.b - 1);
			}
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
