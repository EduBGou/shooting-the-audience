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

    public List<CreatureState> creatureStates = new();
    public CreatureState currentState;
    [Export] public Creature Creature;

    public override void _Ready()
    {
        base._Ready();

        #region Loading, Instantiating and Adding CreatureState Scenes to the List

        var eStateValues = Enum.GetValues(typeof(ECreatureState));
        var baseDir = "res://scenes/creatures/states/Creature";
        for (var i = 0; i < eStateValues.Length; i++)
        {
            var path = $"{baseDir}{eStateValues.GetValue(i)}.tscn";
            var stateScn = GD.Load<PackedScene>(path);
            //Imagino que n esteja chamando o Ready devido ao fato de instanciar como genérico
            var stateInstc = stateScn.Instantiate<CreatureState>();
            stateInstc.Creature = Creature;
            creatureStates.Add(stateInstc);
            AddChild(stateInstc);
            GD.Print(creatureStates[0].Name);
        }
        #endregion

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
