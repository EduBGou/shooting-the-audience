using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class StateMachine : Node
{
    [Export] public Node StateOwner;
    public State CurrentState;

    public override void _Ready()
    {
        base._Ready();
    }

    public virtual void Setup<TEnum, TState>(Dictionary<TEnum, TState> dic)
    where TEnum : Enum where TState : State, IHasEState<TEnum>
    {
        foreach (var child in GetChildren().Cast<TState>())
        {
            dic[child.EState] = child;
            child.StateTransition += (from, to) => OnStateTransition(
                (TState)from, (TEnum)Enum.ToObject(typeof(TEnum), to), dic);
            CustomSetup(child);
        }
    }
    
    public virtual void CustomSetup<TState>(TState state)
    where TState : State { }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (CurrentState == null) return;
        CurrentState.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (CurrentState == null) return;
        CurrentState.PhysicsUpdate(delta);
    }

    public void OnStateTransition<TEnum, TState>(
        TState from, TEnum to, Dictionary<TEnum, TState> dicStates
    ) where TEnum : Enum where TState : State
    {
        if (from != CurrentState) return;
        if (!dicStates.TryGetValue(to, out var newState) || newState == null)
            return;

        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
