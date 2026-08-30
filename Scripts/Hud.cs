using Godot;
using System;

public partial class Hud : Control
{
	// [Export] private Button FightButton; // apenas necessario adicionar o botão no ispetor todo o codigo ja está feito para esse botão.
	[Export] private Qte qte;
	[Signal] public delegate void FightStartedEventHandler();
	[Export] private Label HealthLabel;
	[Export] private Label ResistanceLabel;
	[Export] private Label ActionsLabel;
	
	public override void _Ready()
	{
		LoadStats();
	}
	
	private void OnFightButtonPressed(){
		EmitSignal(SignalName.FightStarted);
		GetTree().ChangeSceneToFile("res://Scenes/FightScene.tscn");
	}

	public void ShowQuickTimeEvent()
	{
		qte.ActivateQte();
	}

	public void UpdateHealth(int current, int max)
	{
		HealthLabel.Text = $"{current}/{max}"; 
	}

	public void UpdateActions(int current, int max)
	{
		ActionsLabel.Text = $"Act.:{current}/{max}";
	}

	public void UpdateResistance(int resistance)
	{
		ResistanceLabel.Text = resistance.ToString();
	}

	public void LoadStats()
	{
		HealthLabel.Text = $"{Global.Instance.Health.ToString()}/{Global.MaxHealth}";
		ActionsLabel.Text = $"Act.:{Global.Instance.Actions.ToString()}/{Global.MaxAction}";
		ResistanceLabel.Text = Global.Instance.Resistance.ToString();
	}

}
