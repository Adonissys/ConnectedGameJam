using Godot;
using System;

public partial class Global : Node
{

	public static Global Instance { get; private set; }

	public int resistance{get; set;} = 0;
	public int health{get; set;} = 0;

	public int CurrentEnemy{get; set;} = 0;
	
	public override void _Ready()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
