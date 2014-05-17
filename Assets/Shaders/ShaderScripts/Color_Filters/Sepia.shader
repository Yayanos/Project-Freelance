Shader "Custom/Sepia"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			
			half grayScale = ((c.r * .3) + (c.g * .59) + (c.b * .11));              
	        
	        // Now apply a sepia filter
	        c.r = grayScale * 1;
	        c.g = grayScale * 0.95;
	        c.b = grayScale * 0.82;
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}