using Godot;
using System;

public partial class JailScene : Node2D
{
	private CharacterBody2D Gladiator;
	private Button RestButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RestButton.ButtonPressed += OnRestButtonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnRestButtonPressed(){
		
	}

}
