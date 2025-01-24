using Godot;

public partial class CreatureHidded : CreatureState
{
    public double hiddedTime;
    public override void Enter()
    {
        base.Enter();
        Creature.Collision.Disabled = true;
        Creature.SignComponent.Visible = false;
        Creature.AnimatedSprite.Animation = "crying";
        hiddedTime = 3;
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
