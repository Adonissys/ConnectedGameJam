using Godot;
using System;

public partial class Hud : Control
{
	[Export] private Button FightButton; // apenas necessario adicionar o botão no ispetor todo o codigo ja está feito para esse botão.
	[Export] private Qte qte;
	

	public override void _Ready()
	{
		FightButton.Pressed += OnFightButtonPressed;
	}
	
	private void OnFightButtonPressed(){
		GetTree().ChangeSceneToFile("res://Scenes/FightScene.tscn");
	}
}
