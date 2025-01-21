using Godot;
using GlobalEnums;

public partial class Creature : Area2D
{
    private GlobalVars GlobalVars;

    public EColor eColor;

    [Export] public AnimatedSprite2D AnimatedSprite;

    public override void _Ready()
    {
        base._Ready();
        GlobalVars = GetNode<GlobalVars>("/root/" + nameof(GlobalVars));
        AnimatedSprite ??= GetNode<AnimatedSprite2D>(nameof(AnimatedSprite));
    }

    public void Dead()
    {
        GlobalVars.Coins++;
        AnimatedSprite.Animation = "dead";
    }
}
