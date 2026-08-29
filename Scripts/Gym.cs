using Godot;
using System;

public partial class Gym : Area2D
{
	private bool IsWorkingOut = false;
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

	private void OnInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if(@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left){
			WorkOut();
			GD.Print("Fui clicado");
		}		
	}
}
