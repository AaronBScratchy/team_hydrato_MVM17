using UnityEngine;
using UnityEngine.InputSystem;
public class PS_Falling : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c)
    {
        name = "Falling";
        base.Init(_a, _m, _s, _c);
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

