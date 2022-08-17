using System;
using UnityEngine;


internal class PS_WallJump : AbstractUpdatingState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);
        name = "Wall Jump";
        clip = Resources.Load<AnimationClip>("AnimationClips/Player/Horn/WallJump");
    }
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        movement.WallJump();
        movement.wallTouch += WallSlide;
        movement.falling += Fall;
        anim.Flip();
        anim.PlayAnimation(clip, false);
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    private void WallSlide()
    {
        OnExit?.Invoke(State.WallSlide);
    }

    protected override void OnFixedUpdate()
    {
        movement.SolveAerialVelocity();
    }

    protected override void OnUpdate()
    {
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        movement.wallTouch -= WallSlide;
        movement.falling -= Fall;

    }
}

