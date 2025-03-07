using Godot;
using System;

public partial class GameStart : GameState
{
    public override void Enter()
    {
        base.Enter();
        ChangeToState(EGameState.Spawn);
    }
}
