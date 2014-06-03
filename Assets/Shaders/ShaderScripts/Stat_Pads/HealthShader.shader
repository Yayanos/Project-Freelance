Shader "Custom/HealthShader" 
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		_Speed ("MoveSpeed", Range(0.1, 1)) = 1
		_RotationSpeed ("Rotation Speed", float) = 1
	}

	SubShader
	{
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		LOD 200
	
		CGPROGRAM
		#pragma surface surf Lambert alphatest:_Cutoff vertex:vert

		sampler2D _MainTex;
		fixed4 _Color;
		half _Speed;

		struct Input
		{
			float2 uv_MainTex;
		};
		
		float _RotationSpeed;

		void vert (inout appdata_full v)
        {
			// You need to be sure to add time in here so the number is constantly changing.
			// Take it out to see what I mean.
            float sinX = sin(_RotationSpeed * _Time.y);
            float cosX = cos(_RotationSpeed * _Time.y);
            float sinY = sin(_RotationSpeed * _Time.y);
            
            float2x2 rotationMatrix = float2x2(cosX, -sinX, sinY, cosX);

			// - 0.5 so that it spins around the center
			// Play with this number so you can see the difference
            v.texcoord.xy = mul(v.texcoord.xy - 0.5, rotationMatrix);
        }

		
		void surf (Input IN, inout SurfaceOutput o)
		{
			float2 uv = IN.uv_MainTex;

			// If we do not offset the image will be shifted by the vertex shader
			// Comment this out to see what I mean.
			uv.xy += 0.5;
			
			fixed4 c = tex2D(_MainTex, uv);

			c *= _Color;

			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}