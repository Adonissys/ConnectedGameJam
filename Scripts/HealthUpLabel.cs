using Godot;
using System;

public partial class HealthUpLabel : Node2D
{
	[Export] private AnimationPlayer animation;
	public void DisplayHeal()
	{
		animation.Play("Appear");
	}
	private void OnAnimationFinished(StringName anim_name)
	{
		QueueFree();
	}
}
