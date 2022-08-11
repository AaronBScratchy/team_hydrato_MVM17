using UnityEngine.InputSystem;
internal class PS_Turning : AbstractUpdatingState
{
    public override void OnStateEnter(PIA actions)
    {
        movement.Turn();
        movement.turnComplete += Run;
        movement.falling += Fall;
        movement.wallTouch += Idle;
        movement.turn += TurnAndRun;
        actions.World.Jump.performed += Jump;
        actions.World.Horizontal.canceled += Idle;
    }

    public override void OnStateExit(PIA actions)
    {
        movement.Turn();
        movement.turnComplete -= Run;
        movement.falling -= Fall;
        movement.wallTouch -= Idle;
        movement.turn -= TurnAndRun;
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

    private void TurnAndRun()
    {
        movement.Turn();
        Run();
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

