Shader "Custom/EnhancedHealthBarShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _BackgroundColor ("Background Color", Color) = (1, 0, 0, 1) // Red
        _Health ("Health", Range(0, 1)) = 1.0 // Health percentage (0 to 1)
        _GlowColor ("Glow Color", Color) = (0, 1, 0, 1) // Green for glow
        _BorderWidth ("Border Width", Range(0, 0.1)) = 0.02
        _BorderColor ("Border Color", Color) = (0, 0, 0, 1) // Black
        _PulseSpeed ("Pulse Speed", Range(0, 5)) = 1.0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 300

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _BackgroundColor;
            float _Health;
            float4 _GlowColor;
            float _BorderWidth;
            float4 _BorderColor;
            float _PulseSpeed;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Create a pulsating effect by using sine wave
            float Pulsate(float health)
            {
                return 1.0 + 0.1 * sin(_PulseSpeed * health * 3.1415);
            }

            float4 frag (v2f i) : SV_Target
            {
                // Sample the texture
                float4 texColor = tex2D(_MainTex, i.uv);

                // Health-based gradient (Green for Full, Red for Empty)
                float3 healthColor = lerp(float3(1, 0, 0), float3(0, 1, 0), _Health);

                // Create a pulsating glow effect for health bar based on health value
                float glowFactor = Pulsate(_Health);
                float3 glowColor = lerp(_GlowColor.rgb, healthColor, glowFactor);

                // Display the gradient health bar
                if (i.uv.x <= _Health)
                {
                    return float4(glowColor, 1) * texColor;
                }
                else
                {
                    // Background color for empty portion
                    return _BackgroundColor * texColor;
                }
            }
            ENDCG
        }
        
        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Stencil
            {
                Ref 1
                Comp Always
                Pass Replace
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _BorderWidth;
            float4 _BorderColor;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // Draw a border for the health bar
                if (i.uv.x < _BorderWidth || i.uv.x > (1.0 - _BorderWidth) || i.uv.y < _BorderWidth || i.uv.y > (1.0 - _BorderWidth))
                {
                    return _BorderColor; // Apply border color
                }
                return float4(0, 0, 0, 0); // Transparent
            }
            ENDCG
        }
    }

    FallBack "Unlit/Transparent"
}
