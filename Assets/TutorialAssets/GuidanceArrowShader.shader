Shader "Custom/AlwaysVisible"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            ZTest Always
            SetTexture [_MainTex] { combine texture }
        }
    }
}

