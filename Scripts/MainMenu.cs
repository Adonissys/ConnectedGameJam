using Godot;
using System;

public partial class MainMenu : Control
{
	[Export] private Button Play;
	[Export] private Button Quit;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnPlayPressed(){
		GetTree().ChangeSceneToFile("res://Scenes/JailScene.tscn");
	}
	
	private void OnQuitPressed(){
		GetTree().Quit();
	}
	
	private void OnPlayMouseEntered(){
		Play.AddThemeColorOverride("font_outline_color", Color.Color8(169,73,73));
	}
	
	private void OnPlayMouseExited(){
		Play.AddThemeColorOverride("font_outline_color", Color.Color8(53, 53, 64));
	}
	
	private void OnQuitMouseEntered(){
		Quit.AddThemeColorOverride("font_outline_color", Color.Color8(169,73,73));
	}
	
	private void OnQuitMouseExited(){
		Quit.AddThemeColorOverride("font_outline_color", Color.Color8(53, 53, 64));
	}
}
