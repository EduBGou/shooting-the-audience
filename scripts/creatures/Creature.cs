using Godot;
using System;

public partial class Creature : Area2D
{
    [Signal] public delegate void DeadSignalEventHandler();
    [Export] public SignComponent SignComponent;

    public CollisionShape2D Collision { get; set; }
    public AnimatedSprite2D AnimatedSprite { get; set; }
    public Armchair Armchair { get; set; }
    public GlobalEnums.EColor EColor { get; set; }
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

    /// <summary>
    /// Leave the current armchair free and place the Creature in a new one.
    /// </summary>
    /// <param name="newArmchair"></param>
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
        var eColorValues = Enum.GetValues(typeof(GlobalEnums.EColor));
        var rdm = new Random().Next(eColorValues.Length);
        EColor = (GlobalEnums.EColor)eColorValues.GetValue(rdm);
    }

    public void Dead()
    {
        EmitSignal(SignalName.DeadSignal);
    }
}
