using UnityEngine;
using UnityEngine.InputSystem;
public class PS_Turning : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "Turning";
        base.Init(_a, _m, _s, _c, _h);
    }

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        anim.PlayAnimation(clip, false);

        movement.Turn();
        movement.turnComplete += Run;
        movement.falling += Fall;
        actions.World.Jump.performed += Jump;
        actions.World.Horizontal.canceled += Idle;
        hurtBehaviour.hurt += GetHurt;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);

        movement.turnComplete -= Run;
        movement.falling -= Fall;
        actions.World.Jump.performed -= Jump;
        actions.World.Horizontal.canceled -= Idle;
        hurtBehaviour.hurt -= GetHurt;
    }

    protected override void OnFixedUpdate()
    {
        movement.ApplyTurn();
    }

    protected override void OnUpdate()
    {
    }
    private void GetHurt()
    {
        OnExit?.Invoke(State.Hurt);
    }

    private void Run()
    {
        OnExit?.Invoke(State.Running);
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    private void Idle()
    {
        OnExit?.Invoke(State.Idle);
    }
    private void Idle(InputAction.CallbackContext obj)
    {
        Idle();
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.JumpSquat);
    }
}

