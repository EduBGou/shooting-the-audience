using Godot;
using System;

public enum EGameState
{
    Start, Spawn, Finished, Store, Paused, Timeout, GameOver
}

[GlobalClass]
public partial class GameState : State, IHasEState<EGameState>
{
    [Export] public EGameState EState { get; set; }
    public GameManager GameManagerOwner { get; set; }
}
