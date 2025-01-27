using Godot;
using GlobalEnums;

public partial class Creature : Area2D
{
    [Signal] public delegate void DeadSignalEventHandler();
    [Export] public SignComponent SignComponent;

    public CollisionShape2D Collision { get; set; }
    public AnimatedSprite2D AnimatedSprite { get; set; }

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
    }

    public void Dead()
    {
        EmitSignal(SignalName.DeadSignal);
    }
}
