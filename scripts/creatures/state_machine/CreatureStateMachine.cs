using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class CreatureStateMachine : Node
{
    public enum ECreatureState
    {
        Idle, Sneaking, Hidded
    }

    public List<CreatureState> creatureStates = new(3);
    public CreatureState currentState;
    [Export] public Creature Creature;

    public override void _Ready()
    {
        base._Ready();
        var eStateValues = Enum.GetValues(typeof(ECreatureState));
        var baseDir = "res://scenes/creatures/states/Creature";
        for (var i = 0; i < eStateValues.Length; i++)
        {
            var path = $"{baseDir}{eStateValues.GetValue(i)}.tscn";
            var stateScn = GD.Load<PackedScene>(path);
            creatureStates.Add(stateScn.Instantiate<CreatureState>());
        }
        currentState = creatureStates[0];
        currentState.Enter();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (currentState == null) return;
        currentState.Update(delta);
    }

    public void ChangeToState(ECreatureState eCreatureState)
    {
        currentState = MapEnumToNodeOfCreatureState(eCreatureState);
    }

    public static CreatureState MapEnumToNodeOfCreatureState(ECreatureState eCreatureState)
    {
        return eCreatureState switch
        {
            ECreatureState.Idle => new CreatureState(),
            ECreatureState.Sneaking => new CreatureState(),
            ECreatureState.Hidded => new CreatureState(),
            _ => new CreatureState(),
        };
    }
}
