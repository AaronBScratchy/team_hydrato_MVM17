using System;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle,
    Running,
    Turning,
    JumpSquat,
    Jumping,
    Falling,
    WallSlide,
    WallJump
}

public class PlayerStateMachine : MonoBehaviour
{
    public Action onFixedUpdate, onUpdate;

    AbstractState[] states;
    AbstractState currentState;
    PIA actions;

    public void Init(PlayerAnimation anim, PlayerMovement moves, PIA pia)
    {
        actions = pia;
        states = new AbstractState[] {
            ScriptableObject.CreateInstance<PS_Idle>(),
            ScriptableObject.CreateInstance<PS_Running>(),
            ScriptableObject.CreateInstance<PS_Turning>(),
            ScriptableObject.CreateInstance<PS_Jumpsquat>(),
            ScriptableObject.CreateInstance<PS_Jump>(),
            ScriptableObject.CreateInstance<PS_Falling>(),
            ScriptableObject.CreateInstance<PS_WallSlide>(),
            ScriptableObject.CreateInstance<PS_WallJump>()
        };

        foreach (AbstractState state in states)
        {
            state.Init(anim, moves, this);
            state.OnExit += StateTransition;
        }

        StateTransition(State.Falling);

    }


    private void StateTransition(State obj)
    {
        AbstractState targetState = obj switch
        {
            State.Idle => states[0],
            State.Running => states[1],
            State.Turning => states[2],
            State.JumpSquat => states[3],
            State.Jumping => states[4],
            State.Falling => states[5],
            State.WallSlide => states[6],
            State.WallJump => states[7],
            _ => states[0]
        };

        if (targetState == currentState) { return; }

        if (currentState != null)
        {
            currentState.OnStateExit(actions);
        }
        currentState = targetState;
        currentState.OnStateEnter(actions);

    }

    void Update()
    {
        onUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        onFixedUpdate?.Invoke();

    }
}
