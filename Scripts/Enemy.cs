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

	private List<Color> _enemyColor = new() {
		new Color("#eeb551"),
		new Color("#e56f4b"),
		new Color("#a94949"),
	};
	private List<int> _enemyDamage = new() {
		5, 8, 12
	};
	private List<int> _enemyStamina = new() {
		80, 100, 130
	}; 
	

	public override void _Ready(){
		_enemyIndex = Global.Instance.CurrentEnemy;
		_damage = _enemyDamage[_enemyIndex];
		_stamina = _enemyStamina[_enemyIndex];

		AttackTimer.Timeout += OnAttackTimerTimeout;
		
		PunchAudio = GD.Load<AudioStream>("res://Audio/SFX/soco3.ogg");

		var shaderMat = EnemySprite.Material as ShaderMaterial;
		if (shaderMat != null){
			shaderMat.SetShaderParameter("replacement_color", _enemyColor[_enemyIndex]);
		}
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
		if (Global.Instance.Outcome != Global.FightOutcome.PENDING) return;

		Audio.Stream = PunchAudio;
		//EnemySprite.Play("attack"+_enemyIndex.ToString());
		EnemySprite.Play("attack");
		Audio.Play();
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);

		if (Global.Instance.Outcome != Global.FightOutcome.PENDING) return;

		EmitSignal(SignalName.Attack, _damage);
		_stamina -= 10;
	}

	private async Task HandleDefeat(){
		Global.Instance.Outcome = Global.FightOutcome.PLAYER_WON;
		//EnemySprite.Play("defeat"+_enemyIndex.ToString());
		EnemySprite.Play("defeat");
		await ToSignal(EnemySprite, AnimatedSprite2D.SignalName.AnimationFinished);
		EmitSignal(SignalName.Defeat);
	}

}
