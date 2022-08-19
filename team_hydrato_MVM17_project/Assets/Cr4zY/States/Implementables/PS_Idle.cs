﻿using UnityEngine;
using UnityEngine.InputSystem;

internal class PS_Idle : AbstractUpdatingState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s, PlayerCharacterSelector _c)
    {
        base.Init(_a, _m, _s, _c);
        name = "Idle";
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
        character.Switch(true);
        movement.Teleport(movement.FindRelativeToMe(Vector2.up*0.25f));
    }
    
    private void ChangeToPrev(InputAction.CallbackContext obj)
    {
        character.Switch(false);
        movement.LoadStats(character.GetCurrentStats());
        stateMachine.RebindStateAnimations(character.CharacterName);
        movement.Teleport(movement.FindRelativeToMe(Vector2.up * 0.25f));
    }
}