using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PS_SlideDodge : AbstractPlayerState
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "Slide";
        base.Init(_a, _m, _s, _c, _h);
    }

    public override void OnStateEnter(PIA actions)
    {
        hurtBehaviour.ToggleIB();
        movement.FacingPosX = !movement.GetComponent<SpriteRenderer>().flipX;
        movement.Launch(movement.FindRelativeToMe(Vector2.right * (movement.FacingPosX ? -1 : 1)), 10);
        anim.PlayAnimation(clip,false);
        anim.animOver += EndSlide;
        movement.falling += Fall;
        movement.wallTouch += EndSlide;
        actions.World.Jump.performed += Jump;

    }

    private void EndSlide()
    {
        OnExit?.Invoke(movement.ResolveGroundState());
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.JumpSquat);
    }

    public override void OnStateExit(PIA actions)
    {
        hurtBehaviour.ToggleIB();
        anim.animOver -= EndSlide;
        movement.falling -= Fall;
        movement.wallTouch -= EndSlide;
        actions.World.Jump.performed -= Jump;
    }

}
