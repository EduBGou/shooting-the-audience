using Godot;
using System;
using System.Collections.Generic;

public partial class State : Node
{
    [Signal]
    public delegate void StateTransitionEventHandler(State from, int to);

    public void ChangeToState <TEnum>( TEnum to)
    where TEnum : Enum
    {
        EmitSignal(SignalName.StateTransition, this, Convert.ToInt32(to));
    }

    public virtual void Enter() { }
    public virtual void Update(double delta) { }
    public virtual void PhysicsUpdate(double delta) { }
    public virtual void Exit() { }
}
