using Godot;

public partial class CreatureSneaking : CreatureState
{
    public double sneakingTime;
    public override void Enter()
    {
        base.Enter();
        sneakingTime = -1;
        CreatureOwner.Collision.Disabled = true;
        CreatureOwner.SignComponent.Visible = true;
        CreatureOwner.AnimatedSprite.Animation = "sneaking";
        CreatureOwner.PlaceOnArmchair(Theater.ChooseRandomArmchair());
        CreatureOwner.ChangeToRandomEColor();
        AppearingTween(.2);
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        sneakingTime = DescontTimeOf(sneakingTime, delta, () =>
        {
            DisappearingTween(.2);
        });
    }

    public override void Exit()
    {
        base.Exit();
        CreatureOwner.SignComponent.Visible = false;
    }

    public override void OnTweenFinished()
    {
        base.OnTweenFinished();
        switch (TweenAction)
        {
            case ETweenAction.Appearing:
                sneakingTime = -sneakingTime;
                break;

            case ETweenAction.Disappearing:
                ChangeToState(ECreatureState.Idle);
                break;
        }
    }
}
