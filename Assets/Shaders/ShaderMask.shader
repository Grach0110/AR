Shader "MyShader/ShaderMask"
{
    SubShader
    {
        Tags
        {
            "Queue" = "Geometry-1"
        }

        Zwrite On

        ColorMask 0

        Pass
        {
            
        }
    }
}