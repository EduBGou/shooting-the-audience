using Godot;
using System;

public partial class GameSpawn : GameState
{
    public override void Enter()
    {
        base.Enter();
        Spawner.Spawn(GlobalVars.CreaturesNode, 10);
    }
}
