using Godot;
using GlobalEnums;

public partial class Creature : Area2D
{
    private GlobalVars GlobalVars;
    public CollisionShape2D Collision { get; set; }
    public AnimatedSprite2D AnimatedSprite { get; set; }
    public AnimationPlayer AnimationPlayer { get; set; }
    [Export] public SignComponent SignComponent;
    public EColor EColor;

    public override void _Ready()
    {
        base._Ready();
        GlobalVars = GetNode<GlobalVars>("/root/" + nameof(GlobalVars));
        Collision = GetNode<CollisionShape2D>(nameof(Collision));
        AnimatedSprite = GetNode<AnimatedSprite2D>(nameof(AnimatedSprite));
        AnimationPlayer = GetNode<AnimationPlayer>(nameof(AnimationPlayer));
    }

    public void Dead()
    {
        GlobalVars.Coins++;
        AnimatedSprite.Animation = "dead";
    }
}
