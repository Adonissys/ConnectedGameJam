using Godot;
using System;

public partial class FightScene : Node2D
{

	[Export] public Enemy CurrentEnemy;
	[Export] public Player CurrentPlayer;
	[Export] public AnimationPlayer TransitionAnimation;
	[Export] private AudioStreamPlayer2D SFX;
	[Export] private AudioStreamPlayer Soundtrack;

	private AudioStream WinAudio;
	private AudioStream DefeatAudio;
	private bool fightEnded;
	private string nextScene;

	public override void _Ready()
	{
		CurrentEnemy.Defeat += OnEnemyDefeat;
		CurrentPlayer.Death += OnPlayerDeath;
		TransitionAnimation.AnimationFinished += OnAnimationFinished;

		Global.Instance.Outcome = Global.FightOutcome.PENDING;
		
		WinAudio = GD.Load<AudioStream>("res://Audio/SFX/win.ogg");
		DefeatAudio = GD.Load<AudioStream>("res://Audio/SFX/lose.ogg");
	}

	public override void _Process(double delta)
	{
		if (fightEnded){
			TransitionAnimation.Play("fade_out");
		}
	}

	private void OnPlayerDeath(){
		Soundtrack.Stop();
		SFX.Stream = DefeatAudio;
		SFX.Play();
		
		fightEnded = true;
	}

	private void OnEnemyDefeat(){
		Soundtrack.Stop();
		SFX.Stream = WinAudio;
		SFX.Play();
		
		fightEnded = true;
	}

	private void OnAnimationFinished(StringName animName){
		if(Global.Instance.Outcome == Global.FightOutcome.PLAYER_WON){
			nextScene = "res://Scenes/JailScene.tscn";
		}else{
			nextScene = "res://Scenes/MainMenu.tscn";
			Global.Instance.ResetGameState();
		}
		GetTree().ChangeSceneToFile(nextScene);
	}
}
