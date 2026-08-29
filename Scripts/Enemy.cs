using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class Enemy : CharacterBody2D {
	
	[Signal] public delegate void DefeatEventHandler();
	[Signal] public delegate void AttackEventHandler();

	[Export] public Timer AttackTimer;
	[Export] public AnimatedSprite2D EnemySprite;

	private int _damage;
	private int _stamina;
	private int _enemyIndex;

	private List<int> _enemyDamage = new() {
		10
	};
	private List<int> _enemyStamina = new() {
		10
	}; 

	public override void _Ready(){
		_enemyIndex = Global.Instance.CurrentEnemy;
		_damage = _enemyDamage[_enemyIndex];
		_stamina = _enemyStamina[_enemyIndex];
	}

	public override void _Process(double _delta){
		if (_stamina <= 0 && Global.Instance.Outcome == Global.FightOutcome.PENDING){
			_ = HandleDefeat();
		}
	}

	private async void OnAttackTimerTimeout(){
		await HandleAttack();
		AttackTimer.Start();
	}

	private async Task HandleAttack(){
		EnemySprite.Play("attack"+_enemyIndex.ToString());
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);
		EmitSignal(SignalName.Attack);
		_stamina -= 10;
	}

	private async Task HandleDefeat(){
		Global.Instance.Outcome = Global.FightOutcome.PLAYER_WON;
		EnemySprite.Play("defeat"+_enemyIndex.ToString());
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);
		EmitSignal(SignalName.Defeat);
	}

}
