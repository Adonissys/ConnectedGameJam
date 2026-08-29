using Godot;
using System;

public partial class Global : Node
{

	public static Global Instance { get; private set; }

	public enum FightOutcome {
		PENDING,
		PLAYER_WON,
		ENEMY_WON
	}
	public FightOutcome Outcome { get; set; }

	private int _health = 0;
	public int Health{
		get => _health; 
		set => _health = Math.Max(0, value);
	}
	public int Resistance{get; set;} = 0;

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
