using Godot;
using System;

public partial class GlobalVars : Node
{
    private GlobalEvents GlobalEvents;

    private int _coin;
    public int Coins
    {
        get => _coin; set
        {
            _coin = value;
            GlobalEvents.EmitSignal(GlobalEvents.SignalName.CoinsAmountChanged, _coin);
        }
    }

    public override void _Ready()
    {
        base._Ready();
        GlobalEvents = GetNode<GlobalEvents>("/root/" + nameof(GlobalEvents));
    }
}
