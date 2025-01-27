using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class CreatureStateMachine : Node
{
    public Dictionary<CreatureState.EState, CreatureState> creatureStates = new();
    public CreatureState currentState;
    [Export] public Creature Creature;

    public override void _Ready()
    {
        base._Ready();

        foreach (var child in GetChildren().Cast<CreatureState>())
        {
            creatureStates[child.State] = child;
            child.Creature = Creature;
            child.StateTransition += OnStateTransition;
            Creature.DeadSignal += child.OnDead;
        }

        currentState = creatureStates[CreatureState.EState.Hidded];
        Creature.Ready += () => { currentState.Enter(); };
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (currentState == null) return;
        currentState.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (currentState == null) return;
        currentState.PhysicsUpdate(delta);
    }

    public void OnStateTransition(CreatureState from, CreatureState.EState to)
    {
        if (from != currentState) return;
        var newState = creatureStates[to];
        if (newState == null) return;
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
