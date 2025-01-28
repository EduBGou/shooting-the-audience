using Godot;

public partial class CreatureHidded : CreatureState
{
    public double hiddedTime;
    public override void Enter()
    {
        base.Enter();
        hiddedTime = -1;
        Creature.Collision.Disabled = true;
        Creature.SignComponent.Visible = false;
        Creature.AnimatedSprite.Animation = "crying";
        hiddedTime = -hiddedTime;
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        hiddedTime = DescontTimeOf(hiddedTime, delta, () =>
        {
            ChangeToState(EState.Sneaking);
        });

    }
}
