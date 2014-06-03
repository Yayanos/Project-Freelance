Shader "Custom/RunCylce" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Blueness("Blueness", Range(0 , 1)) = 1
		_Redness("Redness", Range(0, 1))  =  1
		_Greeness("Greeness", Range(0, 1)) = 0.0
	}
	SubShader
	 {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		half _Blueness;
		half _Redness;
		half _Greeness;
		

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			float2 uv = IN.uv_MainTex;
			half4 c = tex2D (_MainTex, uv);
			///
			c.rgb = (abs(cos(_Time.w))*2);
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}

