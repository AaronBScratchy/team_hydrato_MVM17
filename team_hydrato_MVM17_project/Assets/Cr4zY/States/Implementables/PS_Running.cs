using UnityEngine.InputSystem;
internal class PS_Running : AbstractUpdatingState
{
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        actions.World.Horizontal.canceled += Rest;
        actions.World.Jump.performed += Jump;
        movement.falling += Fall;
        movement.turn += Turn;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        actions.World.Horizontal.canceled -= Rest;
        actions.World.Jump.performed -= Jump;
        movement.falling -= Fall;
        movement.turn -= Turn;
    }

    protected override void OnFixedUpdate()
    {

        movement.SolveGroundedVelocity();

    }

    protected override void OnUpdate()
    {
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    private void Turn()
    {
        OnExit?.Invoke(State.Turning);
    }

    private void Rest(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.Idle);
    }
    private void Jump(InputAction.CallbackContext obj)
    {

        OnExit?.Invoke(State.JumpSquat);

    }
}