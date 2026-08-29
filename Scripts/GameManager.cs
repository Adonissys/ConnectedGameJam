using Godot;
using System;

public partial class GameManager : Node
{
	[Export] private Bed bed;
	[Export] private Gym gym;
	[Export] private Hud hud;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bed.Action += OnAction;
		gym.Action += OnAction;
		hud.FightStarted += OnFightStarted;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnFightStarted(){
		Global.Instance.Actions = 3;
	}
	
	private void OnAction(){
		if(Global.Instance.Actions > 0){
			Global.Instance.Actions -= 1;
		}
 }
}
