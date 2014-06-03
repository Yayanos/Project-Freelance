Shader "Custom/poo"
{
	Properties 
	{
	///creates range from 0-1 and finds a float and returns a value///can be used in equations
		_Color("coluor", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Greeness("GreenScreen", Range(0 , 1)) = 0.8
		_Redness("Redness",  Range(0 , 1 )) = 0.8
		_Blueness("BlueScreen", Range(0 , 1 )) = 0.8
		_Negate("Negate" , Range(0 , 1 )) = 1
		_Whiteness("Whiteness" , Range(0 , 1 )) = 0.5
	}
	

	SubShader
	 {
		Tags { "RenderType"="Opaque" }
		LOD 200
	
	CGPROGRAM
	#pragma surface surf Lambert alpha

	sampler2D _MainTex;
	fixed4 _Color;
	half _Greeness;
	half _Blueness;
	half _Redness;
	half _Negate;	
	half _Whiteness;


	struct Input 
	{
		float2 uv_MainTex;
	};

	void surf (Input IN, inout SurfaceOutput o) 
	{

		

		half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
		
		if( c.r > _Whiteness && c.g > _Whiteness && c.b > _Whiteness )
			c.a = 0;			
			
		
		if(c.g > _Greeness && c.r < 0.5 &&  c.b < 0.5)
			c.a	= 0;
		
		if(c.b > _Blueness && c.g < 0.5 && c.r < 0.5 )
			c.a	= 0;
			
		if(c.r > _Redness && c.b < 0.5 && c.g < 0.5)
			c.a	= 0;
		
		//fixed4 reverse;
		//reverse.r = _Color.b;
		//reverse.g = _Color.g;
		//reverse.b = _Color.r;
		
		c.r = abs(c.b - _Negate);
		c.g = abs(c.g - _Negate);
		c.b = abs(c.r - _Negate);
		
				
		o.Albedo = c.rgb;
		///alpha channel
		o.Alpha = c.a;
	}
	ENDCG
} 
FallBack "Diffuse"
}
