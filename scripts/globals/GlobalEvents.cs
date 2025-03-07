using Godot;
using System;

public partial class GlobalEvents : Node
{
    [Signal]
    public delegate void CoinsAmountChangedEventHandler();
}
