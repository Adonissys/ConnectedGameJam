using Godot;
using System;

public partial class JailScene : Node2D
{

	private CharacterBody2D Gladiator;
	private Button RestButton;

	[Export]private CharacterBody2D Player;
	[Export]private Area2D RestButton;
	
	[Signal] public delegate void ActionEventHandler();

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		RestButton.ButtonPressed += OnRestButtonPressed;

		RestButton.InputEvent += OnRestButtonInput;
		TrainingButton.InputEvent += OnTrainingButtonInput;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	private void OnRestButtonPressed(){}
		

	private void OnRestButtonInput(Node viewport, InputEvent @event, long shapeIdx){
		if(@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left){
			Rest(1);
			GD.Print("Fui clicado");
		}
			
	}
	
	private void Rest(int heal){
		if(true){ //fazer avaliar a quantidade de ações futuramente
			// linha em que o jogador recebe vida pelo descanso
			EmitSignal(SignalName.Action);
			}

	}

}
