Shader "Custom/ScrollingText" {
	Properties {
		_MainTex ("top (RGB)", 2D) = "white" {}
		_SecondaryTex("bottom (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _SecondaryTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_SecondaryTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			
			half2 uv = IN.uv_MainTex;			
			uv.y -= _Time.y;

			
			half4 c = tex2D (_MainTex, uv); 
			half4 mask = tex2D (_SecondaryTex, IN.uv_SecondaryTex);
			
			c.r = 1 - c.r;
			c.g = 1 - c.g;
			c.b = 1 - c.b;
			
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
