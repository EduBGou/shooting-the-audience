using Godot;
using System;
using System.Collections.Generic;

public partial class GlobalVars : Node
{
    public static GlobalEvents GlobalEvents { get; set; }

    public static List<PackedScene> CreaturePckScn =>
    [
        GD.Load<PackedScene>("res://scenes/creatures/Koala.tscn"),
        GD.Load<PackedScene>("res://scenes/creatures/Frog.tscn")
    ];

    public static Theater Theater { get; set; }
    public static Node2D CreaturesNode { get; set; }
    public static Node2D ArmchairsNode { get; set; }

    private static int _coin;
    public static int Coins
    {
        get => _coin; set
        {
            _coin = value;
            GlobalEvents.EmitSignal(GlobalEvents.SignalName.CoinsAmountChanged);
        }
    }

    public override void _Ready()
    {
        base._Ready();
        Theater = GetNode<Theater>("/root/" + "Theater");
        CreaturesNode = Theater.GetNode<Node2D>("Creatures");
        ArmchairsNode = Theater.GetNode<Node2D>("Armchairs");
        GlobalEvents = GetNode<GlobalEvents>("/root/" + nameof(GlobalEvents));
    }
}
