using Godot;
using System;
using GlobalEnums;

[GlobalClass]
public partial class CreatureState : Node
{
    [Signal]
    public delegate void TransitionRequestEventHandler(ECreatureState eCreatureState);

    public Creature Creature { get; set; }
    public virtual void Enter()
    {
        GD.Print("Enter in State: ", Name);
    }
    public virtual void Update(double delta) { }
    public virtual void Exit() { }
    public virtual void OnTimerTimeout() { }

    public void ChangeToState(ECreatureState eCreatureState)
    {
        EmitSignal(SignalName.TransitionRequest, Variant.From(eCreatureState));

    }

    public virtual void OnAnimationPlayerFinishedAnimation(StringName animName) { }

    public void SetCreatureReadyConfigs()
    {
        Creature.AnimationPlayer.AnimationFinished += OnAnimationPlayerFinishedAnimation;
    }

}
