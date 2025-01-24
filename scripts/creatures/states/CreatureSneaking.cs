using Godot;

public partial class CreatureSneaking : CreatureState
{
    public double sneakingTime;
    public override void Enter()
    {
        base.Enter();
        Creature.Collision.Disabled = true;
        Creature.SignComponent.Visible = true;
        Creature.AnimatedSprite.Animation = "sneaking";
        AppearingTween();
    }
    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        sneakingTime = DescontTimeOf(sneakingTime, delta, () =>
        {
            DisappearingTween();
        });
    }

    public override void Exit()
    {
        base.Exit();
        Creature.SignComponent.Visible = false;
    }

    public override void OnTweenFinished()
    {
        base.OnTweenFinished();
        switch (TweenAction)
        {
            case ETweenAction.Appearing:
                sneakingTime = 2;
                break;

            case ETweenAction.Disappearing:
                ChangeToState(EState.Idle);
                break;
        }
    }
}
