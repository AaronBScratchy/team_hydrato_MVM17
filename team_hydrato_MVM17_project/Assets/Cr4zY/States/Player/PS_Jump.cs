using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PS_Jump : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "Jumping";
        base.Init(_a, _m, _s, _c, _h);
    }

    public override void OnStateEnter(PIA actions)
    {
        TurnAdjust(actions.World.Horizontal.ReadValue<float>());
        movement.AddJump();
        base.OnStateEnter(actions);
        anim.PlayAnimation(clip, false);
        movement.falling += Fall;
        actions.World.Horizontal.performed += TurnAdjust;
        actions.World.Attack.performed += AirAttack;
        actions.BrokenHorn.Special.performed += AirDash;
        movement.wallTouch += WallSlide;
        hurtBehaviour.hurt += GetHurt;

    }

    private void AirDash(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.AirDash);
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        movement.falling -= Fall;
        actions.World.Horizontal.performed -= TurnAdjust;
        movement.wallTouch -= WallSlide;
        hurtBehaviour.hurt -= GetHurt;
        actions.World.Attack.performed -= AirAttack;
        actions.BrokenHorn.Special.performed-= AirDash;
    }

    private void AirAttack(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.Aerial);
    }

    protected override void OnFixedUpdate()
    {

        movement.SolveAerialVelocity();

    }

    protected override void OnUpdate()
    {
    }
    private void GetHurt()
    {
        OnExit?.Invoke(State.Hurt);
    }
    private void WallSlide()
    {
        OnExit?.Invoke(State.WallSlide);
    }


    private void TurnAdjust(float obj)
    {
        movement.TurnToPosX(obj > 0);
    }
    private void TurnAdjust(InputAction.CallbackContext obj)
    {
        movement.TurnToPosX(obj.ReadValue<float>() > 0);
    }
    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }
}

