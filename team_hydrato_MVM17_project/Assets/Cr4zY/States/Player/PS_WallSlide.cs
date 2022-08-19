using UnityEngine;
using UnityEngine.InputSystem;

public class PS_WallSlide : AbstractPlayerState
{
    public override void Init(CustomAnimationController _a, PlayerMovement _m, PlayerStateMachine _s, PlayerCharacterSelector _c)
    {
        name = "WallSlide";
        base.Init(_a, _m, _s, _c);
    }
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        movement.ToggleGravity();
        movement.WallSlide();
        anim.SetFlip(movement.FacingPosX);
        actions.World.Jump.performed += WallJump;
        actions.World.Crouch.performed += WallDrop;
        movement.landed += OnLand;
        movement.wallLeft += Fall;
        anim.PlayAnimation(clip, false);
    }

    private void OnLand(bool moving)
    {
        if (moving)
        {
            OnExit?.Invoke(State.Running);
            return;
        }
        OnExit?.Invoke(State.Idle);
    }
    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    private void WallJump(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.WallJump);
    }
    private void WallDrop(InputAction.CallbackContext obj)
    {
        movement.WallDrop();
        Fall();
    }
    public override void OnStateExit(PIA actions)
    {
        movement.ToggleGravity();
        actions.World.Jump.performed -= WallJump;
        actions.World.Crouch.performed -= WallDrop;
        movement.landed -= OnLand;
        movement.wallLeft -= Fall;
    }
}