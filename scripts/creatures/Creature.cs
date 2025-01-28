using Godot;
using GlobalEnums;
using System;

public partial class Creature : Area2D
{
    [Signal] public delegate void DeadSignalEventHandler();
    [Export] public SignComponent SignComponent;

    public CollisionShape2D Collision { get; set; }
    public AnimatedSprite2D AnimatedSprite { get; set; }
    public Armchair Armchair { get; set; }
    public EColor EColor { get; set; }
    public Tween Tween { get; set; }


    public override void _Ready()
    {
        base._Ready();
        Collision = GetNode<CollisionShape2D>(nameof(Collision));
        AnimatedSprite = GetNode<AnimatedSprite2D>(nameof(AnimatedSprite));
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        SignComponent.UpdateEColor(EColor);

    }

    public void PlaceOnArmchair(Armchair newArmchair)
    {
        Armchair?.ChangeFreeFlagTo(true);
        Armchair = newArmchair;
        ZIndex = Armchair.ZIndex - 1;
        GlobalPosition = Armchair.GlobalPosition;
        Armchair.ChangeFreeFlagTo(false);
    }

    public void ChangeToRandomEColor()
    {
        var eColorValues = Enum.GetValues(typeof(EColor));
        var rdm = new Random().Next(eColorValues.Length - 1);
        EColor = (EColor)eColorValues.GetValue(rdm);
    }

    public void Dead()
    {
        EmitSignal(SignalName.DeadSignal);
    }
}
