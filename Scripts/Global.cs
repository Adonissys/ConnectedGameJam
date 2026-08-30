using Godot;
using System;

public partial class Global : Node
{
	[Signal] public delegate void HealthChangedEventHandler(int current, int max);
	[Signal] public delegate void ResistanceChangedEventHandler(int current);
	[Signal] public delegate void ActionChangedEventHandler(int current, int max);
	public static Global Instance { get; private set; }

	public enum FightOutcome {
		PENDING,
		PLAYER_WON,
		ENEMY_WON
	}
	public FightOutcome Outcome { get; set; }

	//Health variables
	public const int MaxHealth = 50;
	private int _health = 50;
	public int Health
	{
    	get => _health;
    	set
    	{
        	_health = Mathf.Clamp(value, 0, MaxHealth);
        	EmitSignal(SignalName.HealthChanged, _health, MaxHealth);
		} 
    }
	
	//Resistance variables
	public const int MinResistance = 5;
	private int _resistance = 5;
	public int Resistance
	{
		get => _resistance;
		set
		{
			_resistance = value;
			EmitSignal(SignalName.ResistanceChanged, _resistance); 
		} 
	} 

	//Action variables
	public const int MaxAction = 3;
	private int _action = 3;
	public int Actions
	{
		get => _action;
		set
		{
			_action = Mathf.Clamp(value, 0, MaxAction);
			EmitSignal(SignalName.ActionChanged, _action, MaxAction);
		}
	}

	public const int MaxEnemy = 3;
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

	public void ResetGameState()
	{
		CurrentEnemy = 0;
		Health = MaxHealth;
		Resistance = MinResistance;
	}

}
