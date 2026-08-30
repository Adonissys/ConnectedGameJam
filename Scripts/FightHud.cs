using Godot;
using System;

public partial class FightHud : Control
{
	[Export] private Label HealthLabel;
	[Export] private Label ResistanceLabel;
	
	public override void _Ready()
	{
		LoadStats();
	}

	public override void _Process(double delta)
	{
		HealthLabel.Text = $"{Global.Instance.Health}/{Global.MaxHealth}"; 
	}

	//public void UpdateHealth(int current)
	//{
	//	HealthLabel.Text = $"{current}/{Global.MaxHealth}"; 
	//}

	public void LoadStats()
	{
		HealthLabel.Text = $"{Global.Instance.Health.ToString()}/{Global.MaxHealth}";
		ResistanceLabel.Text = Global.Instance.Resistance.ToString();
	}

}
