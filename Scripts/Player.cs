using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Signal] public delegate void DeathEventHandler();

	[Export] public Enemy CurrentEnemy;

	[Export] public AnimatedSprite2D PlayerSprite;
	
	public int Health
	{
	    get { return Global.Instance.Health; }
	    set { Global.Instance.Health = value; }

	}
	
	private int _resistance;

	public override void _Ready()
	{
		// CurrentEnemy.Attack += OnEnemyAttack;
		Health = Global.Instance.Health;
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
	    int damage = damageTaken - _resistance;
	    Global.Instance.Health -= damage;  
	    PlayerSprite.Play("hurt");
	    GD.Print(Global.Instance.Health);  
	
	    if (Global.Instance.Health <= 0 && Global.Instance.Outcome == Global.FightOutcome.PENDING)
	    {
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
