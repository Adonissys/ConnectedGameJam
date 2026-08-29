using Godot;
using System;

public partial class Hud : Control
{
	[Export] private Button FightButton; // apenas necessario adicionar o botão no ispetor todo o codigo ja está feito para esse botão.
	[Signal] public delegate void FightStartedEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		FightButton.Pressed += OnFightButtonPressed;
		this.FightStarted += Global.Instance.OnFightStarted;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnFightButtonPressed(){
		EmitSignal(SignalName.FightStarted);
		GetTree().ChangeSceneToFile("res://Scenes/FightScene.tscn");
	}
}
