using Godot;

public partial class CreatureHidded : CreatureState
{
    public double hiddedTime;
    public override void Enter()
    {
        base.Enter();
        hiddedTime = -1;
        CreatureOwner.Collision.Disabled = true;
        CreatureOwner.SignComponent.Visible = false;
        CreatureOwner.AnimatedSprite.Animation = "crying";
        hiddedTime *= -1;
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        hiddedTime = DescontTimeOf(hiddedTime, delta, () =>
        {
            ChangeToState(ECreatureState.Sneaking);
        });

    }
}
