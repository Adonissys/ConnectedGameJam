using Godot;
using System;
using System.Drawing;

public partial class Gauge : Area2D
{
	[Signal] public delegate void GaugeSelectedEventHandler(GaugeQuality gaugeQuality);
	public enum GaugeQuality
    {
		Bad,
		Medium,
		Good
    }
	[Export] public GaugeQuality Quality { get; set; } = GaugeQuality.Bad;
	private bool PointerInGauge = false;
	public bool CanRecieveInput = false;

    public override void _Process(double delta)
    {
        if (PointerInGauge)
        {
            if (Input.IsActionJustPressed("interact"))
            {
				EmitSignal(SignalName.GaugeSelected, (int)Quality);
				GD.Print(Quality);
            }
        }
    }

	private void OnAreaEntered(Area2D area)
	{
		PointerInGauge = true;
	}

	private void OnAreaExited(Area2D area)
	{
		PointerInGauge = false;
	}
}
