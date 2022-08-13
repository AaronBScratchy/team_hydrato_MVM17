using UnityEngine;

internal class PS_Falling : AbstractUpdatingState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);
        name = "Falling";
        clip = Resources.Load<SpriteAnimationClip>("AnimationClips/FallLoop");
    }
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        anim.PlayAnimation(clip, true);

        movement.landed += Land;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        movement.landed -= Land;
    }

    protected override void OnFixedUpdate()
    {
        movement.SolveAerialVelocity();
    }

    protected override void OnUpdate()
    {
    }

    private void Land(bool movementIntended)
    {
        if (movementIntended)
        {
            OnExit?.Invoke(State.Running);
            return;
        }
        OnExit?.Invoke(State.Idle);
    }
}

