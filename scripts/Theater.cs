#nullable disable

using Godot;
using System;

public partial class Theater : Node
{
    public override void _Ready()
    {
        base._Ready();
        Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

}
