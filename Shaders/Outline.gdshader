shader_type canvas_item;

uniform vec4 outline_color : source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform int outline_size : hint_range(1, 10) = 1;
uniform bool outline_enabled = true;

void fragment() {
	vec4 original = texture(TEXTURE, UV);
	vec4 final_color = original;
	
	if (outline_enabled) {
		vec2 pixel_size = TEXTURE_PIXEL_SIZE;
		bool is_outline = false;
		
		if (original.a <= 0.5) {
			for (int x = -outline_size; x <= outline_size; x++) {
				for (int y = -outline_size; y <= outline_size; y++) {
					if (x == 0 && y == 0) continue;
					vec2 offset = vec2(float(x), float(y)) * pixel_size;
					vec4 neighbor = texture(TEXTURE, UV + offset);
					if (neighbor.a > 0.5) {
						is_outline = true;
						break;
					}
				}
				if (is_outline) break;
			}
		}
		
		if (original.a > 0.5) {
			final_color = original;
		} else if (is_outline) {
			final_color = outline_color;
		} else {
			final_color = vec4(0.0, 0.0, 0.0, 0.0);
		}
	}
	
	COLOR = final_color;
}