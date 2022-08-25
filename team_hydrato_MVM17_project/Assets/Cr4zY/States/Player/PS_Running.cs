using UnityEngine;
using UnityEngine.InputSystem;
public class PS_Running : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c)
    {
        name = "Running";
        base.Init(_a, _m, _s, _c);
    }
    public override void OnStateEnter(PIA actions)
    {
        if (movement.Moving)
        {
            //Debug.Log("Run input during movement");
            if (movement.GetComponent<Rigidbody2D>().velocity.x > 0 ^ actions.World.Horizontal.ReadValue<float>() > 0)
            {
                Turn();
                return;
            }

            //Debug.Log("Velocity:\t"+movement.GetComponent<Rigidbody2D>().velocity.x);
            //Debug.Log("Input horizontal:\t"+actions.World.Horizontal.ReadValue<float>());
            //Debug.Log("Values are aligned, continuing into run state...");
        }
        
        base.OnStateEnter(actions);

        anim.SetFlip(actions.World.Horizontal.ReadValue<float>() < 0);
        anim.PlayAnimation(clip, true);

        actions.World.Horizontal.canceled += Rest;
        actions.World.Jump.performed += Jump;
        movement.falling += Fall;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        actions.World.Horizontal.canceled -= Rest;
        actions.World.Jump.performed -= Jump;
        movement.falling -= Fall;
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