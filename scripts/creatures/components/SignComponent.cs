using Godot;

public partial class SignComponent : Node2D
{
    private GlobalEnums.EColor EColor { get; set; }
    public AnimatedSprite2D AnimatedSprite { get; set; }

    public override void _Ready()
    {
        base._Ready();
        AnimatedSprite = GetNode<AnimatedSprite2D>(nameof(AnimatedSprite));
    }

    public void UpdateEColor(GlobalEnums.EColor eColor)
    {
        if (EColor == eColor) return;
        AnimatedSprite.Animation = eColor.ToString().ToSnakeCase();
        EColor = eColor;
    }

    public GlobalEnums.EColor GetEColor()
    {
        return EColor;
    }
}
