using UnityEngine;
using UnityEngine.InputSystem;
internal class PS_Falling : AbstractUpdatingState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s, PlayerCharacterSelector _c)
    {
        base.Init(_a, _m, _s, _c);
        name = "Falling";
    }
    public override void OnStateEnter(PIA actions)
    {
        TurnAdjust(actions.World.Horizontal.ReadValue<float>());
        base.OnStateEnter(actions);
        anim.PlayAnimation(clip, true);

        movement.landed += Land;
        actions.World.Horizontal.performed += TurnAdjust; 
        movement.wallTouch += WallSlide;

    }
    private void WallSlide()
    {
        OnExit?.Invoke(State.WallSlide);
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        movement.landed -= Land;
        actions.World.Horizontal.performed -= TurnAdjust;
        movement.wallTouch -= WallSlide;
    }

    protected override void OnFixedUpdate()
    {
        movement.SolveAerialVelocity();
    }

    protected override void OnUpdate()
    {
    }

    private void TurnAdjust(float obj)
    {
        movement.TurnToPosX(obj > 0);
    }
    private void TurnAdjust(InputAction.CallbackContext obj)
    {
        movement.TurnToPosX(obj.ReadValue<float>() > 0);
    }
    private void Land(bool movementIntended)
    {
        if (movementIntended)
        {
            OnExit?.Invoke(State.Running);
            return;
        }
        OnExit?.Invoke(State.Idle);
    }
}

