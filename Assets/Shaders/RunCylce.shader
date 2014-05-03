Shader "Custom/RunCylce" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SubTex ("Base (RGB)", 2D) = "white" {}
		_SubTex2 ("Base (RGB)", 2D) = "white" {}
		_SubTex3 ("Base (RGB)", 2D) = "white" {}
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _SubTex;
		sampler2D _SubTex2;
		sampler2D _SubTex3;
		
		

		struct Input {
			float2 uv_MainTex;
			float2 uv_SubTex;
			float2 uv_SubTex2;
			float2 uv_SubTex3;
		
		};
		
		void surf (Input IN, inout SurfaceOutput o) 
		{
			float2 uv  = IN.uv_MainTex;
			float2 uv2 = IN.uv_SubTex;
			float2 uv3 = IN.uv_SubTex2;
			float2 uv4 = IN.uv_SubTex3;
			
			
			
			half4 c = tex2D (_MainTex, uv);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
