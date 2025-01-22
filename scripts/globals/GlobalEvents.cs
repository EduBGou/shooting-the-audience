#nullable disable

using Godot;
using System;

public partial class GlobalEvents : Node
{
    [Signal]
    public delegate void CoinsAmountChangedEventHandler(int newAmount);
    [Signal]
    public delegate void IncreaseCoinsAmountEventHandler(int increaseAmount);

}
