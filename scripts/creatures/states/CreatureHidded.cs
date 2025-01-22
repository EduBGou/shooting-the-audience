using GlobalEnums;

public partial class CreatureHidded : CreatureState
{
    public override void Enter()
    {
        base.Enter();
        if (!Creature.Collision.Disabled)
            Creature.Collision.Disabled = true;
    }
}
