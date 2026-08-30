using Godot;
using System;

public partial class FightScene : Node2D
{

	[Export] public Enemy CurrentEnemy;
	[Export] public Player CurrentPlayer;
	[Export] public AnimationPlayer TransitionAnimation;

	private bool fightEnded;
	private string nextScene;

	public override void _Ready()
	{
		CurrentEnemy.Defeat += OnEnemyDefeat;
		CurrentPlayer.Death += OnPlayerDeath;
		TransitionAnimation.AnimationFinished += OnAnimationFinished;

		Global.Instance.Outcome = Global.FightOutcome.PENDING;
	}

	public override void _Process(double delta)
	{
		if (fightEnded){
			TransitionAnimation.Play("fade_out");
		}
	}

	private void OnPlayerDeath(){
		fightEnded = true;
	}

	private void OnEnemyDefeat(){
		fightEnded = true;
	}

	private void OnAnimationFinished(StringName animName){
		if(Global.Instance.Outcome == Global.FightOutcome.PLAYER_WON){
			Global.Instance.CurrentEnemy += 1;
			if (Global.Instance.CurrentEnemy >= Global.MaxEnemy){
				nextScene = "res://Scenes/EndingScene.tscn";
			}else {
				nextScene = "res://Scenes/JailScene.tscn";
			}
			
		}else{
			nextScene = "res://Scenes/MainMenu.tscn";
			Global.Instance.ResetGameState();
		}
		GetTree().ChangeSceneToFile(nextScene);
	}
}
