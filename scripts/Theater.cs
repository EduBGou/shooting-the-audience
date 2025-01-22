using Godot;
using System;

public partial class Theater : Node
{
    public Node2D SpawnPoints { get; set; }

    public override void _Ready()
    {
        base._Ready();
        SpawnPoints = GetNode<Node2D>(nameof(SpawnPoints));
        Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

    public void Spawn()
    {

    }

}
