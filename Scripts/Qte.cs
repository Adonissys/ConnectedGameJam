using Godot;
using Godot.Collections;
using System;
using System.Drawing;

public partial class Qte : Node2D
{
	[Signal] public delegate void QteFinishedEventHandler();
	[Export] public Array<Gauge> Gauges { get; set; } = new();
	[Export] private AnimationPlayer PointerAnimation;
	private int _chances = 0;
	public int Chances
	{
		get => _chances;

		set
		{
			if(value == 0)
			{
				DeactivateQte();
			} 
			_chances = value;
		}
	}


    public override void _Ready()
    {
		Visible = false;
		foreach(Gauge gauge in Gauges)
		{
			gauge.GaugeSelected += OnGaugeSelected;
		}
    }

	public void ActivateQte()
	{
		GD.Print("ActivateQte called!"); 
		GD.Print($"Gauges count: {Gauges?.Count ?? 0}");
		Chances = 3;

		Visible = true;

		foreach(Gauge gauge in Gauges)
		{
			GD.Print("Inside foreach loop"); 
			gauge.CanRecieveInput = true;
			GD.Print($"Activated gauge, CanRecieveInput = {gauge.CanRecieveInput}");
		}

		PointerAnimation.Play("Hover");
	}

	public void DeactivateQte()
	{
		EmitSignal(SignalName.QteFinished);
		
		Visible = false;

		foreach(Gauge gauge in Gauges)
		{
			gauge.CanRecieveInput = false;
		}		

		PointerAnimation.Play("RESET");
	}

	private void OnGaugeSelected(Gauge.GaugeQuality gaugeQuality)
	{
		Chances --;

		switch (gaugeQuality)
		{
			case Gauge.GaugeQuality.Bad:
				Global.Instance.Resistance += 2;
				break;
			case Gauge.GaugeQuality.Medium:
				Global.Instance.Resistance += 4;
				break;
			case Gauge.GaugeQuality.Good:
				Global.Instance.Resistance += 6;
				break;
		}
	}
}
