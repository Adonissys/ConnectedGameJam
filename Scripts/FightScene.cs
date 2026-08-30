using Godot;
using System;

public partial class FightScene : Node2D
{

	[Export] public Enemy CurrentEnemy;
	[Export] public Player CurrentPlayer;
	[Export] public AnimationPlayer TransitionAnimation;
	[Export] private AudioStreamPlayer2D SFX;
	[Export] private AudioStreamPlayer Soundtrack;
	[Export] public Timer TransitionTimer;

	private AudioStream WinAudio;
	private AudioStream DefeatAudio;
	private bool fightEnded;
	private string nextScene;

	public override void _Ready()
	{
		CurrentEnemy.Defeat += OnEnemyDefeat;
		CurrentPlayer.Death += OnPlayerDeath;
		TransitionAnimation.AnimationFinished += OnAnimationFinished;
		TransitionTimer.Timeout += OnTransitionTimerTimeout;

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
		
		TransitionTimer.Start();
	}

	private void OnEnemyDefeat(){
		Soundtrack.Stop();
		SFX.Stream = WinAudio;
		SFX.Play();
		
		TransitionTimer.Start();
	}

	private void OnTransitionTimerTimeout(){
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
