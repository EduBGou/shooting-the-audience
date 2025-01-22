using Godot;
using System.Collections.Generic;
using System.Linq;
using GlobalEnums;
using System;

public partial class CreatureStateMachine : Node
{
    public List<CreatureState> creatureStates = new();
    public CreatureState currentState;
    [Export] public Creature Creature;

    public override void _Ready()
    {
        base._Ready();
        Creature.Ready += OnCreatureReady;

        #region Loading, Instantiating and Adding CreatureState Scenes to the List
        foreach (var child in GetChildren())
        {
            if (child is CreatureState state)
            {
                creatureStates.Add(state);
                state.Creature = Creature;
                state.TransitionRequest += OnTransitionRequested;
                Creature.Ready += state.SetCreatureReadyConfigs;
            }
        }
        #endregion
        currentState = MapEnumToNodeOfCreatureState(ECreatureState.Hidded);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (currentState == null) return;
        currentState.Update(delta);
    }

    public void OnTransitionRequested(ECreatureState eCreatureState)
    {
        currentState.Exit();
        currentState = MapEnumToNodeOfCreatureState(eCreatureState);
        currentState.Enter();
    }

    public CreatureState MapEnumToNodeOfCreatureState(ECreatureState eCreatureState)
    {
        return eCreatureState switch
        {
            ECreatureState.Idle => creatureStates[0],
            ECreatureState.Sneaking => creatureStates[1],
            ECreatureState.Hidded => creatureStates[2],
            _ => creatureStates[2],
        };
    }

    private void OnCreatureReady()
    {
        currentState.Enter();
    }
}
