
using System;
using UnityEngine.InputSystem;

public class PS_WallCling : AbstractPlayerState
{
    bool ready;
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "WallCling";
        base.Init(_a, _m, _s, _c, _h);
    }

    public override void OnStateEnter(PIA actions)
    {


        movement.RestRB();
        movement.ToggleGravity();
        hurtBehaviour.hurt += GetHurt;
        actions.World.Crouch.performed += Fall;
        actions.Scythe.Ability1.performed += SlideDown;
        actions.Scythe.Jump.performed += WallBound;
        anim.animOver += OnCling;
        anim.PlayAnimation(clip, false);

    }
    public override void OnStateExit(PIA actions)
    {
        movement.ToggleGravity();
        hurtBehaviour.hurt -= GetHurt;
        actions.World.Crouch.performed -= Fall;
        actions.Scythe.Ability1.performed -= SlideDown;
        actions.Scythe.Jump.performed -= WallBound;

    }
    private void GetHurt()
    {
        OnExit?.Invoke(State.Hurt);
    }

    private void WallBound(InputAction.CallbackContext obj)
    {
        if (ready)
        {
            OnExit?.Invoke(State.WallBound);
        }
    }

    private void OnCling()
    {
        anim.animOver -= OnCling;
        ready = true;
    }

    private void SlideDown(InputAction.CallbackContext obj)
    {
        if (ready)
        {
            OnExit?.Invoke(State.WallSlide);
        }
    }

    private void Fall(InputAction.CallbackContext obj)
    {
        if (ready)
        {
            movement.WallDrop();

            OnExit?.Invoke(State.Falling);
        }
    }

}

