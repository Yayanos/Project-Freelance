Shader "Custom/BasicMarque" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			float2 uv =  IN.uv_MainTex;
			uv.x *= _SinTime.w + 2;
			uv.y *= _CosTime.w + 2;
			
			
			
			half4 c = tex2D (_MainTex , uv);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
