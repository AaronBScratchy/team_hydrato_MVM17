using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PS_WallJump : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "WallJump";
        base.Init(_a, _m, _s, _c, _h);
    }
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        movement.WallJump();
        movement.wallTouch += WallSlide;
        movement.falling += Fall;
        actions.World.Attack.performed += Attack;
        actions.BrokenHorn.Special.performed += AirDash;
        hurtBehaviour.hurt += GetHurt;
        anim.Flip();
        anim.PlayAnimation(clip, false);
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.Aerial);
    }

    private void AirDash(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.AirDash);
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
        hurtBehaviour.hurt -= GetHurt;
        actions.World.Attack.performed -= Attack;
        actions.BrokenHorn.Special.performed -= AirDash;

    }
    private void GetHurt()
    {
        OnExit?.Invoke(State.Hurt);
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    private void WallSlide()
    {
        OnExit?.Invoke(State.WallSlide);
    }
}

