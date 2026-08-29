using Godot;
using System;

public partial class Bed : Area2D
{
	[Export] private Player Player;
	[Signal] public delegate void ActionEventHandler();
	
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InputEvent += OnRestButtonInput;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	
	}
	
	private void OnRestButtonInput(Node viewport, InputEvent @event, long shapeIdx){
		if(@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left){
			Rest(1);
			GD.Print("Fui clicado");
		}
			
	}
	
	private void Rest(int heal){
		if(Global.Instance.Actions > 0 && Player.Health < Global.Instance.Health){ 
			Player.Health += heal;
			EmitSignal(SignalName.Action);
			}

	}
}
