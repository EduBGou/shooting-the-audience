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

        currentState = statesDic[ECreatureState.Hidded];
        StateOwner.Ready += () => { currentState.Enter(); };
    }

    public override void CustomSetup<TState>(TState state)
    {
        base.CustomSetup(state);
        if (StateOwner is Creature creature && state is CreatureState creatureState)
        {
            creatureState.CreatureOwner = creature;
            creature.DeadSignal += creatureState.OnDead;
        }
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
