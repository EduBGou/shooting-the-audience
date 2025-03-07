using Godot;
using System;
using System.Collections.Generic;

public partial class GameStateMachine : StateMachine
{
    public Dictionary<EGameState, GameState> statesDic = [];
    public override void _Ready()
    {
        base._Ready();
        Setup(statesDic);

        CurrentState = statesDic[EGameState.Start];

        StateOwner.Ready += async () =>
        {
            if (!GlobalVars.Theater.IsNodeReady())
                await ToSignal(GlobalVars.Theater, SignalName.Ready);
            CurrentState.Enter();
        };
    }

    public override void CustomSetup<TState>(TState state)
    {
        base.CustomSetup(state);
        if (StateOwner is GameManager gameManager && state is GameState gameState)
        {
            gameState.GameManagerOwner = gameManager;
        }
    }
}
