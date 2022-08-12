
using System;
using UnityEngine;
using UnityEngine.InputSystem;

internal class PS_Idle : AbstractUpdatingState
{

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);

        actions.World.Horizontal.performed += StartRun;
        actions.World.Jump.performed += Jump;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        actions.World.Horizontal.performed -= StartRun;
        actions.World.Jump.performed -= Jump;
    }

    protected override void OnUpdate()
    {
    }

    protected override void OnFixedUpdate()
    {
        if (!movement.Moving)
        {
            return;
        }
        movement.Decelerate();
    }
    private void StartRun(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.Running);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        OnExit?.Invoke(State.JumpSquat);
    }
}