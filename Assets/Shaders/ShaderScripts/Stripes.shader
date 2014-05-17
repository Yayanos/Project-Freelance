Shader "Custom/Stripes" {
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Stripes("Stripes" , float) = 3
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		half _Stripes;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			
			half x = IN.uv_MainTex.x;
			half y = IN.uv_MainTex.y;
			
			
			//creates center
			
			half width = 0.1;
			
			if(int(x * _Stripes) % 3 != 0)
				c = (c.r + c.g + c.b) / 3;
			

			
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
