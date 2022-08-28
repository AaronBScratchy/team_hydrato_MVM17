using UnityEngine;
using UnityEngine.InputSystem;
public class PS_Running : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "Running";
        base.Init(_a, _m, _s, _c, _h);
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
        }
        
        base.OnStateEnter(actions);
        hurtBehaviour.hurt += GetHurt;

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
        hurtBehaviour.hurt -= GetHurt;
    }

    protected override void OnFixedUpdate()
    {

        movement.SolveGroundedVelocity();

    }

    protected override void OnUpdate()
    {
    }
    private void GetHurt()
    {
        OnExit?.Invoke(State.Hurt);
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