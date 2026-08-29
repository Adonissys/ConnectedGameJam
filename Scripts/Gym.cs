using Godot;
using System;

public partial class Gym : Area2D
{
	private bool IsWorkingOut = false;
	
	[Signal] public delegate void ActionEventHandler();
	
	public override void _Ready()
	{
		this.Action += Global.Instance.OnAction;
	}

	private void WorkOut()
	{
		if(Global.Instance.Actions > 0){ //escrevam a função dentro desse if
			EmitSignal(SignalName.Action);
			}
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
