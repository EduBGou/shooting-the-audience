using Godot;
using System;

public partial class CreatureDead : CreatureState
{
    public override void Enter()
    {
        base.Enter();
        GlobalVars.Coins++;
        CreatureOwner.AnimatedSprite.Animation = "dead";
    }
}
