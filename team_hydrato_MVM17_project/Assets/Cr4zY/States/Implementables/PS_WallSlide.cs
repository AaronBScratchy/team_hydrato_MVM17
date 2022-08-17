using UnityEngine;
using UnityEngine.InputSystem;

public class PS_WallSlide : AbstractState
{
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        name = "Wall Slide";
        clip = Resources.Load<AnimationClip>("url");
        movement.ToggleGravity();
        movement.WallSlide();
        actions.World.Jump.performed += WallJump;
        movement.landed += OnLand;
        movement.wallLeft += Fall;
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

    public override void OnStateExit(PIA actions)
    {
        movement.ToggleGravity();
        actions.World.Jump.performed -= WallJump;
        movement.landed -= OnLand;
        movement.wallLeft -= Fall;
    }
}
