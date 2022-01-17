#version 330

out vec4 outputColor;

uniform vec3 my_color;

void main()
{
    outputColor = vec4(my_color, 1.0);
}