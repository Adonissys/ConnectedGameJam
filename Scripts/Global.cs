using Godot;
using System;

public partial class Global : Node
{
	public int resistence{get; set;} = 0;
	public int health{get; set;} = 0;
	public int attack{get; set;} = 0;
	public int stamina{get; set;} = 0;
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
