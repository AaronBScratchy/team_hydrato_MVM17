using UnityEngine;
using UnityEngine.InputSystem;

internal class PS_Idle : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, Character _c)
    {
        name = "Idle";
        base.Init(_a, _m, _s, _c);
    }

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);

        anim.PlayAnimation(clip, true);

        actions.World.Horizontal.performed += StartRun;
        actions.World.Jump.performed += Jump;
        actions.World.CharacterSwitchFwd.performed += ChangeToNext;
        actions.World.CharacterSwitchBack.performed += ChangeToPrev;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        actions.World.Horizontal.performed -= StartRun;
        actions.World.Jump.performed -= Jump;

        actions.World.CharacterSwitchFwd.performed -= ChangeToNext;
        actions.World.CharacterSwitchBack.performed -= ChangeToPrev;
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
    private void ChangeToNext(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeCharacterWish(true);
    }
    
    private void ChangeToPrev(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeCharacterWish(false);
    }
}