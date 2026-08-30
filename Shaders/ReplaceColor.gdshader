shader_type canvas_item;

uniform vec4 target_color : source_color = vec4(1.0, 0.0, 0.0, 1.0);   
uniform vec4 replacement_color : source_color = vec4(0.0, 0.0, 1.0, 1.0); 
uniform float tolerance : hint_range(0.0, 1.0) = 0.0;                    

void fragment() {
	vec4 original = texture(TEXTURE, UV);
	
	float diff = distance(original.rgb, target_color.rgb);
	
	if (diff < tolerance) {
		COLOR = vec4(replacement_color.rgb, original.a);
	} else {
		COLOR = original;
	}
}