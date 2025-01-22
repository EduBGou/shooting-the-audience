using Godot;
using System;

public partial class CreatureHidded : CreatureState
{
    public override void Enter()
    {
        base.Enter();
        if (!Creature.Collision.Disabled)
            Creature.Collision.Disabled = true;
        Creature.AnimatedSprite.Animation = "hiding";
    }
}
