using System.Collections.Generic;
using Godot;

public partial class Aim : Area2D
{
    public List<Prey> Preys = new();
    public override void _Ready()
    {
        base._Ready();
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
            if (Preys.Count > 0)
            {
                Preys[0].Dead();
            }
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