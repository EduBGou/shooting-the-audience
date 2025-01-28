using Godot;

public partial class CreatureIdle : CreatureState
{
    public double idleTime;
    public override void Enter()
    {
        base.Enter();
        idleTime = -2;
        Creature.SignComponent.Visible = false;
        Creature.AnimatedSprite.Animation = "rage";
        AppearingTween(.2);
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        idleTime = DescontTimeOf(idleTime, delta, () =>
        {
            Creature.Collision.Disabled = true;
            DisappearingTween();
        });
    }


    public override void OnTweenFinished()
    {
        base.OnTweenFinished();
        switch (TweenAction)
        {
            case ETweenAction.Appearing:
                Creature.Collision.Disabled = false;
                idleTime = -idleTime;
                break;

            case ETweenAction.Disappearing:
                ChangeToState(EState.Hidded);
                break;
        }
    }
}
