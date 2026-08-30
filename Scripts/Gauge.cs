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
	[Export] public GaugeQuality Quality { get; set; } 
    private bool _pointerInGauge = false;
    public bool IsPointerInGauge => _pointerInGauge;
	public bool CanRecieveInput = false;

	public override void _Process(double delta)
	{
		// if (PointerInGauge && CanRecieveInput)
		// {
		// 	if (Input.IsActionJustPressed("interact"))
		// 	{
		// 		EmitSignal(SignalName.GaugeSelected, (int)Quality);
		// 		GD.Print(Quality);
		// 	}
		// }
	}

	private void OnAreaEntered(Area2D area)
	{
		_pointerInGauge = true;
	}

	private void OnAreaExited(Area2D area)
	{
		_pointerInGauge = false;
	}

    public void ResetGaugeState()
    {
        _pointerInGauge = false;
        CanRecieveInput = false;
    }
}
