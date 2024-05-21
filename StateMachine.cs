using Godot;
using NXR;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class StateMachine : Node
{

	public State CurrentState { get; set; }
	public Dictionary<string, State> States { get; set; } = new();


    public override void _Ready()
    {
        foreach (Node child in GetChildren()) { 
			if (Util.NodeIs(child, typeof(State))) { 
				State state = (State)child; 
				States.Add(child.Name, state); 
				state.Transition += SwitchState;
				CurrentState ??= state; 
                CurrentState.EmitSignal("StateEntered"); 
			}
		}
    }

    public void SwitchState(string newState) { 
		CurrentState?.EmitSignal("StateExited"); 
		States[newState]?.EmitSignal("StateEntered"); 
		
		CurrentState = States[newState]; 
	}

    public override void _Process(double delta)
    {
        CurrentState?.Update(delta); 
    }


    public override void _PhysicsProcess(double delta)
    {
        CurrentState?.PhysicsUpdate(delta); 
    }
}
