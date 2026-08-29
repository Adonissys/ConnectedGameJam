using Godot;
using System;

public partial class Gym : Area2D
{

	[Signal] public delegate void GymCalledEventHandler();
	[Export] private AnimatedSprite2D Sprite;
	private bool WorkingOut = false;	
	[Signal] public delegate void ActionEventHandler();
	

	public override void _Ready()
	{
	}

	private void WorkOut()
	{

		if(WorkingOut && Global.Instance.Actions == 0) return;

		WorkingOut = true;
		EmitSignal(SignalName.GymCalled);
		EmitSignal(SignalName.Action);
		Sprite.Play("WorkOut");
	}

	public void StopWorkingOut()
	{
		WorkingOut = false;
		Sprite.Play("Idle");
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
