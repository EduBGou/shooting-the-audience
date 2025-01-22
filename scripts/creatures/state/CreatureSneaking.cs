using Godot;
using System;

public partial class CreatureSneaking : CreatureState
{
    public override void _Ready()
    {
        base._Ready();
    }

    public override void Enter()
    {
        base.Enter();

        Creature.AnimatedSprite.Animation = "sneaking";
        Creature.SignComponent.ChangeEColorTo(Creature.EColor);

    }
}
