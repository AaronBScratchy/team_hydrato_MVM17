﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PS_Idle : AbstractUpdatingPS
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c)
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
        StartCharacterChange(true);
    }

    private void ChangeToPrev(InputAction.CallbackContext obj)
    {
        StartCharacterChange(false);
    }
    private void StartCharacterChange(bool next)
    {
        selector.ChangeCharacter(next);
        stateMachine.RebindStateAnimations(selector.CurrentCharacter.ToString());
        movement.LoadStats(Resources.Load<CharacterStats>("Player Stats").GetStats(selector.CurrentCharacter));
        movement.Teleport(movement.FindRelativeToMe(Vector2.up*0.25f));
        OnExit?.Invoke(State.Falling);
    }
}