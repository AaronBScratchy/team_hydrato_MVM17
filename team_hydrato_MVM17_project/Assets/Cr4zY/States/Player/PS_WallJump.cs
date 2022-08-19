using System;
using UnityEngine;


internal class PS_WallJump : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, PlayerMovement _m, PlayerStateMachine _s, PlayerCharacterSelector _c)
    {
        name = "WallJump";
        base.Init(_a, _m, _s, _c);
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

