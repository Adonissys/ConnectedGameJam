using Godot;
using System;

public partial class EndingScene : Control
{
	[Export] public Timer SceneTimer;

	public override void _Ready()
	{
		SceneTimer.Timeout += OnSceneTimerTimeout;
	}

	public override void _Process(double delta)
	{
	}

	private void OnSceneTimerTimeout(){
		GetTree().ChangeSceneToFile("res://Scenes/EndingScene.tscn");
	}
}
