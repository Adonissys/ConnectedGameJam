using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class Enemy : CharacterBody2D {
	
	[Signal] public delegate void DefeatEventHandler();
	[Signal] public delegate void AttackEventHandler(int baseDamage);

	[Export] public Timer AttackTimer;
	[Export] public AnimatedSprite2D EnemySprite;
	[Export] private AudioStreamPlayer2D Audio;

	private AudioStream PunchAudio;
	private AudioStream DeathAudio;
	private int _damage;
	private int _stamina;
	private int _enemyIndex;

	private List<int> _enemyDamage = new() {
		50, 75, 100
	};
	private List<int> _enemyStamina = new() {
		100, 120, 150
	}; 

	public override void _Ready(){
		_enemyIndex = Global.Instance.CurrentEnemy;
		_damage = _enemyDamage[_enemyIndex];
		_stamina = _enemyStamina[_enemyIndex];

		AttackTimer.Timeout += OnAttackTimerTimeout;
		
		PunchAudio = GD.Load<AudioStream>("res://Audio/SFX/soco.ogg");
	}

	public override void _Process(double _delta){
		if (_stamina <= 0 && Global.Instance.Outcome == Global.FightOutcome.PENDING){
			_ = HandleDefeat();
		}
	}

	private async void OnAttackTimerTimeout(){
		await HandleAttack();
		if (Global.Instance.Outcome == Global.FightOutcome.PENDING){
			AttackTimer.Start();
		}
	}

	private async Task HandleAttack(){
		Audio.Stream = PunchAudio;
		EnemySprite.Play("attack"+_enemyIndex.ToString());
		Audio.Play();
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);
		EmitSignal(SignalName.Attack, _damage);
		_stamina -= 10;
	}

	private async Task HandleDefeat(){
		Global.Instance.Outcome = Global.FightOutcome.PLAYER_WON;
		EnemySprite.Play("defeat"+_enemyIndex.ToString());
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);
		EmitSignal(SignalName.Defeat);
	}

}
