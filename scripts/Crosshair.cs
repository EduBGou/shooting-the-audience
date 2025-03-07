
using System.Collections.Generic;
using Godot;
using System.Linq;

public partial class Crosshair : Area2D
{
    public List<Creature> TargetCreatures = new();
    public Sprite2D Sprite { get; set; }
    public GlobalEnums.EColor EColor = GlobalEnums.EColor.Red;

    public override void _Ready()
    {
        base._Ready();
        Sprite = GetNode<Sprite2D>(nameof(Sprite));

        AreaEntered += OnAreaEntered;
        AreaExited += OnAreaExited;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Position = GetGlobalMousePosition();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            if (TargetCreatures.Count > 0)
            {
                var target = TargetCreatures.Last();
                if (target.EColor == EColor && !target.Collision.Disabled)
                {
                    target.Dead();
                    TargetCreatures.Remove(target);
                }
            }
        }

        // Change the Crosshair color by Input
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            ChangeEColor(MapKeysToEColor(keyEvent));
        }
    }

    public void ChangeEColor(GlobalEnums.EColor newEColor)
    {
        var imgDir = $"res://sprites/crosshair/{newEColor}.png";
        if (FileAccess.FileExists(imgDir))
        {
            var newTexture = ResourceLoader.Load<Texture2D>(imgDir);
            Sprite.Texture = newTexture ?? Sprite.Texture;
        }
        else
        {
            GD.PrintErr($"\"{imgDir}\" -> Don't exists!");
            return;
        }
        EColor = newEColor;
    }

    public static GlobalEnums.EColor MapKeysToEColor(InputEventKey keyEvent)
    {
        return keyEvent.KeyLabel switch
        {
            Key.Key1 => GlobalEnums.EColor.Red,
            Key.Key2 => GlobalEnums.EColor.Green,
            Key.Key3 => GlobalEnums.EColor.Blue,
            Key.Key4 => GlobalEnums.EColor.Yellow,
            _ => GlobalEnums.EColor.Red,
        };
    }

    #region Adding and Removing areas in/from List "Preys"
    private void OnAreaEntered(Area2D area)
    {
        if (area is Creature creature)
            TargetCreatures.Add(creature);
    }

    private void OnAreaExited(Area2D area)
    {
        if (area is Creature creature)
            TargetCreatures.Remove(creature);
    }
    #endregion
}