using Godot;
using System;

public partial class QualityLabel : Node2D
{
	[Export] private AnimationPlayer Animation;
	[Export] private RichTextLabel richTextLabel;

	public void DisplayQuality(Gauge.GaugeQuality gaugeQuality)
	{
		switch (gaugeQuality)
		{
			case Gauge.GaugeQuality.Bad:
				richTextLabel.Text = "[color=#ca5954][wave]Bad![/wave][/color]";
				break;
			case Gauge.GaugeQuality.Medium:
				richTextLabel.Text = "[color=#e8c65b][wave]Medium![/wave][/color]";
				break;
			case Gauge.GaugeQuality.Good:
				richTextLabel.Text = "[rainbow][wave]Good![/wave][/rainbow]";
				break;
		}

		Animation.Play("Appear");
	}

	private void OnAnimationFinished(StringName anim_name)
	{
		QueueFree();
	}
}
