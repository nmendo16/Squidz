Shader "Custom/ExplosionShader" {
    Properties {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Color ("Explosion Color", Color) = (1, 0.5, 0, 1)
        _GlowIntensity ("Glow Intensity", Range(0, 5)) = 1.0
        _ExpansionSpeed ("Expansion Speed", Float) = 1.0
        _FadeSpeed ("Fade Speed", Float) = 1.0
    }

    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Pass {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _GlowIntensity;
            float _ExpansionSpeed;
            float _FadeSpeed;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target {
                float2 uv = i.uv;

                // Simulate expansion using time
                float expansion = _Time.y * _ExpansionSpeed;
                uv -= 0.5; // Center UVs
                uv *= 1.0 + expansion;
                uv += 0.5;

                // Sample the texture
                float4 texColor = tex2D(_MainTex, uv);

                // Add a glow effect using distance from center
                float2 center = float2(0.5, 0.5);
                float dist = distance(uv, center);
                float glow = exp(-dist * _GlowIntensity);

                // Combine texture and glow
                float4 color = texColor * _Color;
                color.rgb += glow;

                // Fade out over time
                color.a *= max(0, 1.0 - (_Time.y * _FadeSpeed));

                return color;
            }
            ENDCG
        }
    }

    FallBack "Unlit/Transparent"
}
