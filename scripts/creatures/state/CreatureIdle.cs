using Godot;
using System;

public partial class CreatureIdle : CreatureState
{
    public override void Enter()
    {
        base.Enter();
        if (Creature.Collision.Disabled)
            Creature.Collision.Disabled = false;
        Creature.AnimatedSprite.Animation = "appearing";
        GD.Print("Here");
    }
}
