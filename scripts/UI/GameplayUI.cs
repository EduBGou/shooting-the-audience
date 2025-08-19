using Godot;
using System;

public partial class GameplayUI : Control
{
    public Label CoinsLabel { get; set; }

    public override void _Ready()
    {
        base._Ready();
        CoinsLabel = GetNode<Label>(nameof(CoinsLabel));
        GlobalVars.GlobalEvents.CoinsAmountChanged += OnCoinAmountChanged;
    }

    private void OnCoinAmountChanged()
    {
        CoinsLabel.Text = $"Pnts: {GlobalVars.Coins}";
    }
}
