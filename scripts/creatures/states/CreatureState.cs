using Godot;
using System;

public enum ECreatureState
{
    Idle, Sneaking, Hidded, Dead
}

[GlobalClass]
public partial class CreatureState : State, IHasEState<ECreatureState>
{
    protected enum ETweenAction { Appearing, Disappearing };

    [Export] public ECreatureState EState { get; set; }

    public Creature CreatureOwner { get; set; }
    protected ETweenAction TweenAction { get; set; }

    public virtual void OnTweenFinished() { }

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
        CreatureOwner.Tween = GetTree().CreateTween();
        CreatureOwner.Tween.TweenProperty(
            CreatureOwner, "global_position",
            new Vector2(CreatureOwner.GlobalPosition.X,
                CreatureOwner.GlobalPosition.Y + pos), duration)
            .SetEase(Tween.EaseType.InOut)
            .SetTrans(Tween.TransitionType.Cubic);
        CreatureOwner.Tween.Finished += OnTweenFinished;
    }
}