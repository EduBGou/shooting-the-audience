using Godot;

public partial class Armchair : Node2D
{
    [Signal] public delegate void UpdatedIsFreeFlagEventHandler(Armchair armchair, bool isFree);
    private bool IsFree = false;

    public override void _Ready()
    {
        base._Ready();
    }

    public bool GetIsFree()
    {
        return IsFree;
    }

    public void ChangeFreeFlagTo(bool isFree)
    {
        IsFree = isFree;
        EmitSignal(SignalName.UpdatedIsFreeFlag, this, isFree);
    }
}
