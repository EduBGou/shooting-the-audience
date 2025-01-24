using Godot;

public partial class CreatureIdle : CreatureState
{
    public double idleTime;
    public override void Enter()
    {
        base.Enter();
        Creature.Collision.Disabled = false;
        Creature.SignComponent.Visible = false;
        Creature.AnimatedSprite.Animation = "rage";
        AppearingTween();
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        idleTime = DescontTimeOf(idleTime, delta, () =>
        {
            DisappearingTween();
        });
    }

    public override void OnTweenFinished()
    {
        base.OnTweenFinished();
        switch (TweenAction)
        {
            case ETweenAction.Appearing:
                idleTime = 4;
                break;

            case ETweenAction.Disappearing:
                ChangeToState(EState.Hidded);
                break;
        }
    }
}
