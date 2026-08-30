using Godot;
using System;

public partial class GameManager : Node
{
	[Export] private Bed bed;
	[Export] private Gym gym;
	[Export] private Hud hud;
	
	public override void _Ready()
	{
		bed.Action += OnAction;
		gym.Action += OnAction;
		gym.GymCalled += OnGymCalled;
		hud.FightStarted += OnFightStarted;
		Global.Instance.ActionChanged += OnActionChanged;
		Global.Instance.HealthChanged += OnHealthChanged;
		Global.Instance.ResistanceChanged += OnResistanceChanged;
	}

    public override void _ExitTree()
    {
       
        if (bed != null) bed.Action -= OnAction;
        if (gym != null)
        {
            gym.Action -= OnAction;
            gym.GymCalled -= OnGymCalled;
        }
        if (hud != null) hud.FightStarted -= OnFightStarted;
        if (Global.Instance != null)
        {
            Global.Instance.ActionChanged -= OnActionChanged;
            Global.Instance.HealthChanged -= OnHealthChanged;
            Global.Instance.ResistanceChanged -= OnResistanceChanged;
        }
    }

	private void OnFightStarted(){
		Global.Instance.Actions = 3;
	}
	
	private void OnAction(){
		if(Global.Instance.Actions > 0){
			Global.Instance.Actions -= 1;
		}

 	}

	private void OnGymCalled()
	{
		hud.ShowQuickTimeEvent();
	}

	private void OnActionChanged(int current, int max)
	{
		hud.UpdateActions(current, max);
	}

	private void OnHealthChanged(int current, int max)
	{
		hud.UpdateHealth(current, max);
	}

	private void OnResistanceChanged(int current)
	{
		hud.UpdateResistance(current);
	}
}
