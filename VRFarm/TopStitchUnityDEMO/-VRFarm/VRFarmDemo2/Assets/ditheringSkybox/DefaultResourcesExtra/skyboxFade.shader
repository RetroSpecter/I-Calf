Shader "Skybox/12 Sided" {
Properties {
	_Tint ("Tint Color", Color) = (.5, .5, .5, .5)
	[Gamma] _Exposure ("Exposure", Range(0, 8)) = 1.0
	_Rotation ("Rotation", Range(0, 360)) = 0
	_Blend ("Blend", Range(0,100)) = 50

	[NoScaleOffset] _FrontTex ("Front [+Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _BackTex ("Back [-Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _LeftTex ("Left [+X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _RightTex ("Right [-X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _UpTex ("Up [+Y]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _DownTex ("Down [-Y]   (HDR)", 2D) = "grey" {}

	[NoScaleOffset] _FrontTex2 ("Front [+Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _BackTex2 ("Back2 [-Z]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _LeftTex2 ("Left2 [+X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _RightTex2 ("Right2 [-X]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _UpTex2 ("Up2 [+Y]   (HDR)", 2D) = "grey" {}
	[NoScaleOffset] _DownTex2 ("Down2 [-Y]   (HDR)", 2D) = "grey" {}
}

SubShader {
	Tags { "Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
	Cull Off ZWrite Off
	
	CGINCLUDE
	#include "UnityCG.cginc"

	half4 _Tint;
	half _Exposure;
	float _Rotation;
	float _Blend;

	float3 RotateAroundYInDegrees (float3 vertex, float degrees)
	{
		float alpha = degrees * UNITY_PI / 180.0;
		float sina, cosa;
		sincos(alpha, sina, cosa);
		float2x2 m = float2x2(cosa, -sina, sina, cosa);
		return float3(mul(m, vertex.xz), vertex.y).xzy;
	}
	
	struct appdata_t {
		float4 vertex : POSITION;
		float2 texcoord : TEXCOORD0;
	};
	struct v2f {
		float4 vertex : SV_POSITION;
		float2 texcoord : TEXCOORD0;
	};
	v2f vert (appdata_t v)
	{
		v2f o;
		float3 rotated = RotateAroundYInDegrees(v.vertex, _Rotation);
		o.vertex = UnityObjectToClipPos(rotated);
		o.texcoord = v.texcoord;
		return o;
	}
	half4 skybox_frag (v2f i, sampler2D smp, half4 smpDecode)
	{
		half4 tex = tex2D (smp, i.texcoord);
		half3 c = DecodeHDR (tex, smpDecode);
		c = c * _Tint.rgb * unity_ColorSpaceDouble.rgb;
		c *= _Exposure;
		return half4(c, 1);
	}

	half4 skybox_frag (v2f i, sampler2D smp, half4 smpDecode, sampler2D smp2, half4 smpDecode2)
	{
		half4 tex = tex2D (smp, i.texcoord) * (1,1,1,_Blend);
		tex = tex + tex2D (smp2, i.texcoord) * (1,1,1,1 - _Blend);
		half3 c = DecodeHDR (tex, smpDecode);
		c = c * _Tint.rgb * unity_ColorSpaceDouble.rgb;
		c *= _Exposure;
		return half4(c, 1);
	}

	ENDCG
	
	Pass {
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _FrontTex;
		half4 _FrontTex_HDR;
		sampler2D _FrontTex2;
		half4 _FrontTex_HDR2;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_FrontTex, _FrontTex_HDR,_FrontTex2, _FrontTex_HDR2); }
		ENDCG 
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _BackTex;
		half4 _BackTex_HDR;
		sampler2D _BackTex2;
		half4 _BackTex_HDR2;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_BackTex, _BackTex_HDR, _BackTex2, _BackTex_HDR2); }
		ENDCG 
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _LeftTex;
		half4 _LeftTex_HDR;
		sampler2D _LeftTex2;
		half4 _LeftTex_HDR2;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_LeftTex, _LeftTex_HDR,_LeftTex2, _LeftTex_HDR2); }
		ENDCG
	}
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _RightTex;
		half4 _RightTex_HDR;
		sampler2D _RightTex2;
		half4 _RightTex_HDR2;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_RightTex, _RightTex_HDR,_RightTex2, _RightTex_HDR2); }
		ENDCG
	}	
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _UpTex;
		half4 _UpTex_HDR;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_UpTex, _UpTex_HDR); }
		ENDCG
	}	
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma target 2.0
		sampler2D _DownTex;
		half4 _DownTex_HDR;
		sampler2D _DownTex2;
		half4 _DownTex_HDR2;
		half4 frag (v2f i) : SV_Target { return skybox_frag(i,_DownTex, _DownTex_HDR,_DownTex2, _DownTex_HDR2); }
		ENDCG
	}
}
}
