using Godot;
using System;
using System.Collections.Generic;

public partial class CreatureStateMachine : StateMachine
{
    public Dictionary<ECreatureState, CreatureState> statesDic = [];
    public override void _Ready()
    {
        base._Ready();
        Setup(statesDic);

        if (StateOwner is Creature creature)
            creature.DeadSignal += OnDead;

        CurrentState = statesDic[ECreatureState.Hidded];
        StateOwner.Ready += () => { CurrentState.Enter(); };
    }

    public override void CustomSetup<TState>(TState state)
    {
        base.CustomSetup(state);
        if (StateOwner is Creature c && state is CreatureState cState)
            cState.CreatureOwner = c;
    }

    private void OnDead()
    {
        CurrentState.ChangeToState(ECreatureState.Dead);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }
}
