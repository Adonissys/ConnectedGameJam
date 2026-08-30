using Godot;
using System;

public partial class DamageLabel : Node2D
{
	[Export] private AnimationPlayer animation;
	[Export] private RichTextLabel Label;

	public void DisplayDamage(int damage)
	{
		if(damage < 0) damage = 0;
		Label.Text = $"[wave]-{damage} HP![/wave]";
		animation.Play("Appear");
	}

	private void OnAnimationFinished(StringName anim_name)
	{
		QueueFree();
	}
}
