using Godot;
using System;

public partial class CreatureDead : CreatureState
{
    private GlobalVars GlobalVars;

    public override void _Ready()
    {
        base._Ready();
        GlobalVars = GetNode<GlobalVars>($"/root/{nameof(GlobalVars)}");
    }

    public override void Enter()
    {
        base.Enter();
        GlobalVars.Coins++;
        CreatureOwner.AnimatedSprite.Animation = "dead";
    }
}
