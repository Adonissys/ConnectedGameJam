using Godot;
using System;

public partial class Gym : Area2D
{
	
	public override void _Ready()
	{
	}

	private void WorkOut()
	{
		
	}

	private void Outline(bool enabled)
	{
		switch (enabled)
		{
			case true:
				//Outline.Play("DisplayOutline");
				break;
			case false:
				//Outline.Play("StopOutline");
				break;
		}
	}

	private void OnMouseEntered()
	{
		Outline(true);
	}

	private void OnMouseExited()
	{
		Outline(false);
	}
}
