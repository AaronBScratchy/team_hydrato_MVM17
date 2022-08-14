using System;
using UnityEngine;
using UnityEngine.InputSystem;

internal class PS_Jumpsquat : AbstractState
{
    float start, release;
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);

        name = "Jump squat";
        clip = Resources.Load<SpriteAnimationClip>("AnimationClips/JumpSquat");
    }

    public override void OnStateEnter(PIA actions)
    {
        start = Time.time;
        release = start;
        base.OnStateEnter(actions);
        anim.PlayAnimation(clip, false);
        anim.animOver += TakeOff;
        actions.World.Jump.canceled += OnJumpRelease;
    }

    public override void OnStateExit(PIA actions)
    {
        anim.animOver -= TakeOff;
        actions.World.Jump.canceled -= OnJumpRelease;
    }
    private void OnJumpRelease(InputAction.CallbackContext obj)
    {
        release = Time.time;
    }


    private void TakeOff()
    {
        movement.CacheJump(release-start, Time.time-start);

        OnExit?.Invoke(State.Jumping);
    }

}