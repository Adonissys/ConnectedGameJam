using Godot;
using System;
using System.Threading.Tasks;

public partial class Enemy : CharacterBody2D {
	
	[Signal] public delegate void DefeatEventHandler();

	[Export] public Timer AttackTimer;
	[Export] public AnimatedSprite2D EnemySprite;

	private int _damage;
	private int _stamina;

	public void Initialize(int damage, int stamina) {
		_damage = damage;
		_stamina = stamina;
	}

	private async void OnAttackTimerTimeout(){
		await HandleAttack();
		AttackTimer.Start();
	}

	private async Task HandleAttack(){
		EnemySprite.Play("attack");
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);
		_stamina -= 10;
		if (_stamina <= 0){
			await HandleDefeat();
		}
	}

	private async Task HandleDefeat(){
		EnemySprite.Play("defeat");
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);
		EmitSignal(SignalName.Defeat);
	}

}
