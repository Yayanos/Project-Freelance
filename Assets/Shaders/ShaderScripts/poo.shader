Shader "Custom/poo"
{
	Properties 
	{
	///creates range from 0-1 and finds a float and returns a value///can be used in equations
		_Color("coluor", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Greeness("GreenScreen", Range(0 , 1)) = 0.8
		_Blueness("BlueScreen", Range(0 , 1)) = 0.8
		_Redness("Redness", Range(0, 1)) =  0.8
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
	///or
	///float _Greeness;

	struct Input 
	{
		float2 uv_MainTex;
	};

	void surf (Input IN, inout SurfaceOutput o) 
	{
		///does not need uv and can be used in equations 
		fixed4 reverse;
		reverse.r = _Color.b;
		reverse.g = _Color.g;
		reverse.b = _Color.r;
		
		//_Color.b *= 0.5;
		
		///sets a limit between colors 
		//if (Color.r > 0.5)
		//	_Color.b = 0;
		
		////mathmatical calc between colors and return values of rgb
		
		///color for main image and and outputs UV and multiplies with color
		///and applies then returns image with changes
		half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
		
		///if a certain color becomes greater than it changes it to zero and intensifies the color affect
		///applicable to each channel. 
		//if(c.r < 0.5)
		//	c.r	= 0;
		if(c.g > _Greeness && c.r < 0.5 &&  c.b < 0.5)
			c.a	= 0;
			
		if(c.g > 0.5 && c.r < 0.5 &&  c.b < _Blueness)
			c.a	= 0;
			
		if(c.g > 0.5 && c.r < _Redness &&  c.b < 0.5)
			c.a	= 0;
			
		
		//if(c.b < 0.5)
		//	c.b	= 0;
		
		//c.a = abs(c.g - 1);		
				
		o.Albedo = c.rgb;
		///alpha channel
		o.Alpha = c.a;
	}
	ENDCG
} 
FallBack "Diffuse"
}
