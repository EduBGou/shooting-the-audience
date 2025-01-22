using Godot;
using System;
using GlobalEnums;

public partial class CreatureIdle : CreatureState
{
    public override void Enter()
    {
        base.Enter();
        if (Creature.Collision.Disabled)
            Creature.Collision.Disabled = false;

        Creature.AnimatedSprite.Animation = "rage";
        Creature.SignComponent.Visible = false;
        Creature.AnimationPlayer.Play("appearing");
        
    }
}
