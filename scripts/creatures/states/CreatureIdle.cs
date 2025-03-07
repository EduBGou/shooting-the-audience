using Godot;

public partial class CreatureIdle : CreatureState
{
    public double idleTime;
    public override void Enter()
    {
        base.Enter();
        idleTime = -2;
        CreatureOwner.SignComponent.Visible = false;
        CreatureOwner.AnimatedSprite.Animation = "rage";
        AppearingTween(.2);
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        idleTime = DescontTimeOf(idleTime, delta, () =>
        {
            CreatureOwner.Collision.Disabled = true;
            DisappearingTween(.2);
        });
    }


    public override void OnTweenFinished()
    {
        base.OnTweenFinished();
        switch (TweenAction)
        {
            case ETweenAction.Appearing:
                CreatureOwner.Collision.Disabled = false;
                idleTime = -idleTime;
                break;

            case ETweenAction.Disappearing:
                ChangeToState(ECreatureState.Hidded);
                break;
        }
    }
}
