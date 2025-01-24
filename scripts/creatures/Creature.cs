using Godot;
using GlobalEnums;

public partial class Creature : Area2D
{
    [Export] public SignComponent SignComponent;

    public CollisionShape2D Collision { get; set; }
    public AnimatedSprite2D AnimatedSprite { get; set; }

    public EColor EColor { get; set; }
    public Tween Tween { get; set; }

    private GlobalVars GlobalVars;

    public override void _Ready()
    {
        base._Ready();
        GlobalVars = GetNode<GlobalVars>("/root/" + nameof(GlobalVars));
        Collision = GetNode<CollisionShape2D>(nameof(Collision));
        AnimatedSprite = GetNode<AnimatedSprite2D>(nameof(AnimatedSprite));
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public void Dead()
    {
        GlobalVars.Coins++;
        AnimatedSprite.Animation = "dead";
    }
}
