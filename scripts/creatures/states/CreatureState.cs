using Godot;
using System;

[GlobalClass]
public partial class CreatureState : Node
{
    [Signal]
    public delegate void StateTransitionEventHandler(CreatureState from, EState to);

    public enum EState { Idle, Sneaking, Hidded, Dead }
    protected enum ETweenAction { Appearing, Disappearing };

    [Export] public EState State { get; set; }

    public Creature Creature { get; set; }
    protected ETweenAction TweenAction { get; set; }

    public virtual void Enter() { }
    public virtual void Update(double delta) { }
    public virtual void PhysicsUpdate(double delta) { }
    public virtual void Exit() { }

    public virtual void OnTweenFinished() { }

    public void ChangeToState(EState eState)
    {
        if (State == eState) return;
        EmitSignal(SignalName.StateTransition, this, Variant.From(eState));
    }

    public static double DescontTimeOf(double cTime, double delta, Action func)
    {
        double retTime = cTime;

        if (retTime > 0)
            retTime -= delta;

        if (retTime > -1 && retTime < 0)
        {
            func();
            return -1;
        }
        return retTime;
    }

    // Develog a more dynamic and flexible way to manipulate tween animations
    public void AppearingTween(double duration = .5)
    {
        TweenAction = ETweenAction.Appearing;
        AnimTween(-18, duration);
    }

    public void DisappearingTween(double duration = .5)
    {
        TweenAction = ETweenAction.Disappearing;
        AnimTween(18, duration);
    }

    private void AnimTween(int pos, double duration)
    {
        Creature.Tween = GetTree().CreateTween();
        Creature.Tween.TweenProperty(
            Creature, "global_position",
            new Vector2(Creature.GlobalPosition.X,
                Creature.GlobalPosition.Y + pos), duration)
            .SetEase(Tween.EaseType.InOut)
            .SetTrans(Tween.TransitionType.Cubic);
        Creature.Tween.Finished += OnTweenFinished;
    }

    public void OnDead()
    {
        ChangeToState(EState.Dead);
    }
}