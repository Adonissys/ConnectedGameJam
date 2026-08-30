using Godot;
using System;

public partial class Bed : Area2D
{
	[Export] private Player Player;
	[Signal] public delegate void ActionEventHandler();
	[Export] private AnimatedSprite2D PlayerSprite;
	[Export] private PackedScene HealthUpLabelScene;
	[Export] private Timer SleepTimer;
	[Export] private AnimationPlayer OutlineAnim;
	[Export] private AudioStreamPlayer2D SFX;
	private bool IsSleeping = false;
	
	
	public override void _Ready()
	{
		InputEvent += OnRestButtonInput;
		PlayerSprite.Visible = false;
	}
	
	private void OnRestButtonInput(Node viewport, InputEvent @event, long shapeIdx)
	{
		if(@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			// Rest(1);
			Sleep();
			GD.Print("Fui clicado");
		}		
	}
	

	private void Sleep()
	{
	    if(IsSleeping || Global.Instance.Actions == 0 || Player.Health >= Global.MaxHealth) return;
	
	    IsSleeping = true;
	    Player.Visible = false;
	    PlayerSprite.Visible = true;
	    SleepTimer.Start();
		SFX.Play();
	}

	private void Rest(int heal)
	{
		Player.Health += heal;
		EmitSignal(SignalName.Action);
		GD.Print("I rested");
	}

	private void OnSleepTimerTimeout()
	{
		IsSleeping = false;
		PlayerSprite.Visible = false;
		SFX.Stop();
		Player.Visible = true;
		Rest(15);
		InitializeHealthUpLabel();
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
		if(IsSleeping) return;
		Outline(true);
	}

	private void OnMouseExited()
	{
		Outline(false);
	}

	private void InitializeHealthUpLabel()
	{
		var HealthUpLabel = HealthUpLabelScene.Instantiate<HealthUpLabel>();
		GetTree().CurrentScene.AddChild(HealthUpLabel);
		HealthUpLabel.GlobalPosition = PlayerSprite.GlobalPosition;
		HealthUpLabel.DisplayHeal();
	}
}
