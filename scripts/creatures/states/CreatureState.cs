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

    public virtual void Enter() { GD.Print("Enter in State: ", Name); }
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

        if (retTime < 0 && retTime != -1)
        {
            func();
            return -1;
        }
        return retTime;
    }

    // Develog a more dynamic and flexible way to manipulate tween animations
    public void AppearingTween()
    {
        TweenAction = ETweenAction.Appearing;
        AnimTween(-18);
    }

    public void DisappearingTween()
    {
        TweenAction = ETweenAction.Disappearing;
        AnimTween(18);
    }

    private void AnimTween(int pos)
    {
        Creature.Tween = GetTree().CreateTween();
        Creature.Tween.TweenProperty(
            Creature, "global_position",
            new Vector2(Creature.GlobalPosition.X,
                Creature.GlobalPosition.Y + pos), .5)
            .SetEase(Tween.EaseType.InOut)
            .SetTrans(Tween.TransitionType.Cubic);
        Creature.Tween.Finished += OnTweenFinished;
    }

    public void OnDead()
    {
        // Some Implementation
        ChangeToState(EState.Dead);
    }
}