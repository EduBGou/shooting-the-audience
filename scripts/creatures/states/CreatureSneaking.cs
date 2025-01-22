using Godot;

using GlobalEnums;
public partial class CreatureSneaking : CreatureState
{
    public override void Enter()
    {
        base.Enter();
        if (!Creature.Collision.Disabled)
            Creature.Collision.Disabled = true;
        Creature.SignComponent.Visible = true;
        Creature.AnimatedSprite.Animation = "sneaking";
        Creature.AnimationPlayer.Play("appearing");
        Creature.SignComponent.ChangeEColorTo(Creature.EColor);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void OnAnimationPlayerFinishedAnimation(StringName animName)
    {
        base.OnAnimationPlayerFinishedAnimation(animName);
        if (animName == "disappearing")
            ChangeToState(ECreatureState.Idle);
        if (animName == "appearing")
            Creature.AnimationPlayer.Play("disappearing");
    }
}
