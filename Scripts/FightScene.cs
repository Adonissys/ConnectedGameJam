using Godot;
using System;

public partial class FightScene : Node2D
{

	[Export] public Enemy CurrentEnemy;
	[Export] public Player CurrentPlayer;

	private bool fightEnded;

	public override void _Ready()
	{
		CurrentEnemy.Defeat += OnEnemyDefeat;
		CurrentPlayer.Death += OnPlayerDeath;
	}

	public override void _Process(double delta)
	{
		if (fightEnded){
			if(Global.Instance.Outcome == Global.FightOutcome.PLAYER_WON){

			}else{
				
			}
		}
	}

	private void OnPlayerDeath(){
		fightEnded = true;
	}

	private void OnEnemyDefeat(){
		fightEnded = true;
	}
}
