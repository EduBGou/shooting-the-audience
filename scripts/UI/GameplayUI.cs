#nullable disable

using Godot;
using System;

public partial class GameplayUI : Control
{
    private GlobalEvents GlobalEvents;
    public Label CoinsLabel { get; set; }

    public override void _Ready()
    {
        base._Ready();
        GlobalEvents = GetNode<GlobalEvents>("/root/" + nameof(GlobalEvents));
        CoinsLabel = GetNode<Label>(nameof(CoinsLabel));
        GlobalEvents.CoinsAmountChanged += OnCoinAmountChanged;
    }

    private void OnCoinAmountChanged(int newAmount)
    {
        CoinsLabel.Text = $"Coins: {newAmount}";
    }
}
