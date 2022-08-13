using UnityEngine;
using UnityEngine.InputSystem;

internal class PS_Idle : AbstractUpdatingState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);
        name = "Idle";
        clip = Resources.Load<SpriteAnimationClip>("AnimationClips/Idle");
    }

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);

        anim.PlayAnimation(clip, true);

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