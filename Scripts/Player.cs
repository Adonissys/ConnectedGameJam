using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Signal] public delegate void DeathEventHandler();

	[Export] public Enemy CurrentEnemy;
	[Export] public AnimationPlayer PlayerAnimation;

	private int _health;
	
	public int Health
	{
		get { return _health; }
		set 	
		{	 
			_health = value; 
		}
	}
	
	private int _resistance;

	public override void _Ready()
	{
		CurrentEnemy.Attack += OnEnemyAttack;
		PlayerAnimation.AnimationFinished += OnAnimationFinished;
		_health = Global.Instance.Health;
		_resistance = Global.Instance.Resistance;

		//PlayerAnimation.Play("idle");
	}

	public override void _Process(double delta)
	{	
		if (Global.Instance.Outcome == Global.FightOutcome.PLAYER_WON){
			//Player won logic
		}
	}

	private void TakeDamage(int damageTaken)
	{
		_health -= (damageTaken-_resistance);
		//PlayerAnimation.Play("hurt");
		if (_health <= 0 && Global.Instance.Outcome == Global.FightOutcome.PENDING){
			HandleDeath();
		}
	}

	private void HandleDeath()
	{
		Global.Instance.Outcome = Global.FightOutcome.ENEMY_WON;
		//PlayerAnimation.Play("death");
	}

	private void OnEnemyAttack(int baseDamage){
		TakeDamage(baseDamage);
	}

	private void OnAnimationFinished(StringName animName){
		if (animName == "death"){
			EmitSignal(SignalName.Death);
		}else{
			//PlayerAnimation.Play("idle");
		}

	}
	
}
