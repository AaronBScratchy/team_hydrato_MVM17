using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PS_Jumpsquat : AbstractPlayerState
{
    float start, release;
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c)
    {
        name = "JumpSquat";
        base.Init(_a, _m, _s, _c);
    }

    public override void OnStateEnter(PIA actions)
    {
        start = Time.time;
        release = start;
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
        movement.CacheJump(release - start, Time.time - start);

        OnExit?.Invoke(State.Jumping);
    }

}