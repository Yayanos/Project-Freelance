Shader "Custom/pooVER2" 
{
	Properties
	 {
		_Color("Colour" ,Color) = (1,1,1,1)
		_MainTexture("picture " , 2D) = " white "{}
		_Negate("Negate" , Range(0 ,1 )) = 1
		
		
	 }
	 SubShader 
	 {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert
		
		fixed4 _Color;
		sampler2D _MainTexture;
		half _Negate;
		
		struct Input 
		{
			float2 uv_MainTexture;
			
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half4 c  = tex2D (_MainTexture, IN.uv_MainTexture) * _Color;
			
			c.r = abs(c.b - _Negate);
			c.g = abs(c.g - _Negate);
			c.b = abs(c.r - _Negate);
			
			o.Albedo = c.rgb;
			
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
