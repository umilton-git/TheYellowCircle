// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// --------------------------------------------------------------------------------
// Shader by:
//		-  Jorge Jimenez - Jorge@iryku.com - www.iryoku.com
// shader source code: from "www.iryoku.com" power-point Slides 229-231.
// http://www.iryoku.com/downloads/Next-Generation-Character-Rendering-v6.pptx.
// --------------------------------------------------------------------------------
//	    -  Implemented to Unity by: Anmar Al-Sharif ~AnmarCG~ - shark0259@gmail.com
// --------------------------------------------------------------------------------

Shader "custom/eye"
{
	Properties
	{
		_IrisTex ("Texture", 2D) = "white" {}
		_MaskTex ("Texture", 2D) = "white" {}
		_anteriorChamberDepth ("Depth",Range(0.0,2.0)) = 1.0
		_radius ("Radius",Range(0.0,2.0)) = 0.216
		_IOR ("Index Of Refraction",Range(0.0,2.0)) = 0.568
		_frontNormalW ("Front Normal",Vector) = (0,0,1)

	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma exclude_renderers gles
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float3 normal : TEXCOORD1;
				float3 viewW  : TEXCOORD2;
			};

			sampler2D _IrisTex;
			sampler2D _MaskTex;

			float _anteriorChamberDepth;
			float _radius;
			float _IOR;
			fixed4 _frontNormalW;

			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;//TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				float3 worldPos = mul(unity_ObjectToWorld,v.vertex);
				float3 worldEyePos = _WorldSpaceCameraPos;
				o.viewW = normalize(worldEyePos - worldPos);
				o.normal = normalize(mul(unity_ObjectToWorld,v.normal));

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				//fixed4 col = tex2D(_IrisTex, i.uv);
				fixed3 normalW = i.normal;
				float height = _anteriorChamberDepth * saturate( 1.0 - 18.4 * _radius * _radius ); 

				// Refration
				float w = _IOR * dot( normalW, i.viewW );
    			float k = sqrt( 1.0 + ( w - _IOR ) * ( w + _IOR ) );
    			float3 refractedW = ( w - k ) * normalW - _IOR * i.viewW;

    			float mask = tex2D(_MaskTex,i.uv).r;
    			fixed2 eyeUV = i.uv;

    			float cosAlpha = dot(_frontNormalW, -refractedW);
				float dist = height / cosAlpha;
				float3 offsetW = dist * refractedW;
				float2 offsetL =  mul(offsetW,(float3x2)unity_ObjectToWorld);
				eyeUV += float2(mask,-mask) * offsetL;
	
				float3 eyeRef = tex2D(_IrisTex,eyeUV);

				//float ndotl = dot(i.viewW,n);
				fixed4 col = fixed4(eyeRef,1);
				return col;
			}
			ENDCG
		}
	}
}
