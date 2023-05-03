Shader "Shader Learn/OutLighting"  //Shader文件索引路径

    // 属性
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SelfColor("SelfColor",Color) = (1,1,1)
        _Threshold("threshold",Range(0,1)) = 0.2
        _Strength("Strength",Range(0,1)) = 1
        _Size("lightSize",Range(0,5)) = 0.1
        _OutLightPow("pow",Range(0,2)) = 1
        _OutLightStrength("outLightStrength",Range(0,2)) = 1
        _NormalSize("NormalSize",Range(0,1)) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
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
                float4 vertex : SV_POSITION;
                float3 worldNormal : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _SelfColor;
            float _Threshold;
            float _Strength;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                float3 worldNormal = normalize(i.worldNormal);
                float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
                float cosValue = dot(worldNormal, viewDir);
                //cos值大于阈值时不实现自发光效果
                if (cosValue >= _Threshold) {
                    cosValue = 1;
                }
                return col + _SelfColor * (1-cosValue)*_Strength;
            }
            ENDCG
        }
        Pass
        {
            Tags{ "LightMode" = "Always" }
            Blend SrcAlpha One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"            

            struct appdata
        {
            float4 vertex : POSITION;
            float3 normal : NORMAL;

        };

        struct v2f
        {
            float4 vertex : SV_POSITION;
            float3 worldNormal : TEXCOORD1;
            float4 worldPos : TEXCOORD2;
        };

        sampler2D _MainTex;
        float4 _MainTex_ST;
        float4 _SelfColor;
        float _Threshold;
        float _Strength;
        float _Size;
        float _OutLightPow;
        float _OutLightStrength;
        float _NormalSize;
        v2f vert(appdata v)
        {
            v.vertex.xyz += v.normal * _Size;
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);
            o.worldPos = mul(unity_ObjectToWorld, v.vertex);
            return o;
        }

        fixed4 frag(v2f i) : SV_Target
        {
            // sample the texture
            float3 worldNormal = normalize(i.worldNormal);
            float3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
            float cosValue = dot(worldNormal, viewDir);
            if (cosValue <= _NormalSize) {
                //cosValue = 1;
            }
            else {
                cosValue = 0;
            }
            float4 color = _SelfColor;
            color.a = pow(saturate(cosValue),_OutLightPow);
            //_OutLightStrength += cos(10 * _Time.x);
            color.a *= _OutLightStrength * dot(viewDir, i.worldNormal);
            return color;
        }
            ENDCG
        }
    }
}