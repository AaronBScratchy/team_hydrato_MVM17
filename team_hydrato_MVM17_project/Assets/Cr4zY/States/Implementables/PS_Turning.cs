using UnityEngine;
using UnityEngine.InputSystem;
internal class PS_Turning : AbstractUpdatingState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);

        name = "Turning";
        clip = Resources.Load<SO_AnimationClip>("AnimationClips/Idle");
    }

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);

        movement.Turn();
        anim.Flip();

        movement.turnComplete += Run;
        movement.falling += Fall;
        actions.World.Jump.performed += Jump;
        actions.World.Horizontal.canceled += Idle;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        movement.turnComplete -= Run;
        movement.falling -= Fall;
        actions.World.Jump.performed -= Jump;
        actions.World.Horizontal.canceled -= Idle;
    }

    protected override void OnFixedUpdate()
    {
        movement.ApplyTurn();
    }

    protected override void OnUpdate()
    {
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

