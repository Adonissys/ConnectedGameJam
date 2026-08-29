using Godot;
using System;
using System.Drawing;

public partial class Qte : Node2D
{
	[Export] public Godot.Collections.Array<Gauge> Gauges {get; set;}
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
			_chances= value;
		}
	}


    public override void _Ready()
    {
		foreach(Gauge gauge in Gauges)
		{
			gauge.GaugeSelected += OnGaugeSelected;
		}
    }

	public void ActivateQte()
	{
		Chances = 3;

		Visible = true;

		foreach(Gauge gauge in Gauges)
		{
			gauge.CanRecieveInput = true;
		}

		PointerAnimation.Play("hover");
	}

	public void DeactivateQte()
	{
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
