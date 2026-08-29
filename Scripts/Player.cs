using Godot;
using System;

public partial class Player : CharacterBody2D
{

	public override void _PhysicsProcess(double delta)
	{

	}

	private void TakeDamage()
	{
		if (Global.Instance.Health <= 0 && Global.Instance.Outcome == Global.FightOutcome.PENDING){
			HandleDeath();
		}
	}

	private void HandleDeath()
	{
		
	}
	
}
