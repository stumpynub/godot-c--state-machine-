using Godot;
using System;

namespace NXR; 
public partial class State : Node
{	

	StateMachine Statemachine; 

	[Signal] public delegate void StateEnteredEventHandler();
	[Signal] public delegate void StateExitedEventHandler();
	[Signal] public delegate void TransitionEventHandler(string stateName); 

    public virtual void Update(double delta){}
	public virtual void PhysicsUpdate(double delta){}
		
}
