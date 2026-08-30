using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Signal] public delegate void DeathEventHandler();

	[Export] public Enemy CurrentEnemy;
	[Export] public AnimatedSprite2D PlayerSprite;

	private int _health;
	
	public int Health
	{
		get { return _health; }
		set 	
		{	 
			_health = Math.Clamp(value, 0, Global.MaxHealth);
		}
	}
	
	private int _resistance;

	public override void _Ready()
	{
		if (CurrentEnemy != null){
			CurrentEnemy.Attack += OnEnemyAttack;
		}
		PlayerSprite.AnimationFinished += OnAnimationFinished;
		Health = Global.Instance.Health;
		_resistance = Global.Instance.Resistance;

		PlayerSprite.Play("idle");
	}

	private void TakeDamage(int damageTaken)
	{
		Health -= (damageTaken-_resistance);
		PlayerSprite.Play("hurt");
		GD.Print(Health);
		if (Health <= 0 && Global.Instance.Outcome == Global.FightOutcome.PENDING){
			HandleDeath();
		}
	}

	private void HandleDeath()
	{
		Global.Instance.Outcome = Global.FightOutcome.ENEMY_WON;
		PlayerSprite.Play("death");
	}

	private void OnEnemyAttack(int baseDamage){
		TakeDamage(baseDamage);
	}

	private void OnAnimationFinished(){
		if (Global.Instance.Outcome == Global.FightOutcome.ENEMY_WON){
			EmitSignal(SignalName.Death);
		}else{
			PlayerSprite.Play("idle");
		}
	}
	
}
