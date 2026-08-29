using Godot;
using System;

public partial class Hud : Control
{
	[Export] private Button FightButton; // apenas necessario adicionar o botão no ispetor todo o codigo ja está feito para esse botão.
	[Export] private Qte qte;
	[Signal] public delegate void FightStartedEventHandler();
	

	public override void _Ready()
	{
		FightButton.Pressed += OnFightButtonPressed;
	}
	
	private void OnFightButtonPressed(){
		EmitSignal(SignalName.FightStarted);
		GetTree().ChangeSceneToFile("res://Scenes/FightScene.tscn");
	}

	public void ShowQuickTimeEvent()
	{
		qte.ActivateQte();
	}
}
