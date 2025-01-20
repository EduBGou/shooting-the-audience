
using System.Collections.Generic;
using Godot;
using GlobalEnums;

public partial class Crosshair : Area2D
{
    public List<Prey> Preys = new();
    public Sprite2D Sprite { get; set; }
    public EColor eColor = EColor.Red;

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

        #region Configure the Aim Color

        var imgDir = $"res://sprite/crosshair/{eColor}.png";
        if (FileAccess.FileExists(imgDir))
        {
            var newTexture = ResourceLoader.Load<Texture2D>(imgDir);
            Sprite.Texture = newTexture ?? Sprite.Texture;
        }
        #endregion
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            if (Preys.Count > 0)
                Preys[0].Dead();
        }

        // Change the Crosshair color by Input
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            eColor = keyEvent.KeyLabel switch
            {
                Key.Key1 => EColor.Red,
                Key.Key2 => EColor.Green,
                Key.Key3 => EColor.Blue,
                Key.Key4 => EColor.Yellow,
                _ => EColor.Red,
            };
        }
    }

    #region Adding and Removing areas in/from List "Preys"
    private void OnAreaEntered(Area2D area)
    {
        if (area is Prey prey)
            Preys.Add(prey);
    }

    private void OnAreaExited(Area2D area)
    {
        if (area is Prey prey)
            Preys.Remove(prey);
    }
    #endregion

}