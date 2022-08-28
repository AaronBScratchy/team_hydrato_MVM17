using UnityEngine.InputSystem;

public class PS_WallSlide : AbstractPlayerState
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "WallSlide";
        base.Init(_a, _m, _s, _c, _h);
    }
    public override void OnStateEnter(PIA actions)
    {
        movement.ToggleGravity();
        movement.WallSlide();
        anim.SetFlip(movement.FacingPosX);
        actions.BrokenHorn.Jump.performed += WallJump;
        actions.Scythe.Ability1.performed += WallCling;
        actions.World.Crouch.performed += WallDrop;
        movement.landed += OnLand;
        movement.wallLeft += Fall;
        anim.PlayAnimation(clip, false);
        hurtBehaviour.hurt += GetHurt;
    }
    public override void OnStateExit(PIA actions)
    {
        movement.ToggleGravity();
        actions.BrokenHorn.Jump.performed -= WallJump;
        actions.World.Crouch.performed -= WallDrop;
        actions.Scythe.Ability1.performed -= WallCling;
        movement.landed -= OnLand;
        movement.wallLeft -= Fall;
        hurtBehaviour.hurt -= GetHurt;
    }
    private void GetHurt()
    {
        OnExit?.Invoke(State.Hurt);
    }

    private void WallCling(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.WallCling);
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
}
