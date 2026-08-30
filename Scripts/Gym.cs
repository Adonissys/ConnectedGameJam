using Godot;
using System;

public partial class Gym : Area2D
{
	[Signal] public delegate void GymCalledEventHandler();
	[Export] private AnimatedSprite2D Sprite;
	[Export] private Player Player;
	[Export] private AnimatedSprite2D PlayerSprite;
	[Export] private Qte qte;
	[Export] private AnimationPlayer OutlineAnim;
	[Export] private AudioStreamPlayer2D SFX;
	private bool WorkingOut = false;	
	[Signal] public delegate void ActionEventHandler();
	
	public override void _Ready()
	{
		qte.QteFinished += OnQteFinished;
	}

	private void WorkOut()
	{

		if(WorkingOut || Global.Instance.Actions == 0) return;

		WorkingOut = true;
		EmitSignal(SignalName.GymCalled);
		EmitSignal(SignalName.Action);
		Sprite.Play("Active");
		Player.Visible = false;
		SFX.Play();
		PlayerSprite.Visible = true;
	}

	public void StopWorkingOut()
	{
		WorkingOut = false;
		Sprite.Play("Inactive");
		PlayerSprite.Visible = false;
		SFX.Stop();
		Player.Visible = true;
	}

	private void Outline(bool enabled)
	{
		switch (enabled)
		{
			case true:
				OutlineAnim.Play("OutlineOn");
				break;
			case false:
				OutlineAnim.Play("OutlineOff");
				break;
		}
	}

	private void OnMouseEntered()
	{
		if(WorkingOut) return;
		Outline(true);
	}

	private void OnMouseExited()
	{
		Outline(false);
	}

	private void OnQteFinished()
	{
		StopWorkingOut();
	}

	private void OnInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if(@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left){
			WorkOut();
		}		
	}
}
