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
    WallJump,
    WallCling,
    WallBound,
    Attacking,
    Hurt,
    Aerial,
    AirDash,
    Sliding
}

public class CharacterStateMachine : MonoBehaviour
{
    public Action onFixedUpdate, onUpdate;

    Dictionary<State, AbstractPlayerState> states = new();
    AbstractPlayerState currentState;
    PIA actions;

    public void Init(CustomAnimationController anim, CharacterMovement moves, CharacterSelect character, PlayerHurtBehaviour hurtBehaviour, PIA pia)
    {
        actions = pia;

        states.Add(State.Idle, ScriptableObject.CreateInstance<PS_Idle>());
        states.Add(State.Running, ScriptableObject.CreateInstance<PS_Running>());
        states.Add(State.Turning, ScriptableObject.CreateInstance<PS_Turning>());
        states.Add(State.JumpSquat, ScriptableObject.CreateInstance<PS_Jumpsquat>());
        states.Add(State.Jumping, ScriptableObject.CreateInstance<PS_Jump>());
        states.Add(State.Falling, ScriptableObject.CreateInstance<PS_Falling>());
        states.Add(State.WallSlide, ScriptableObject.CreateInstance<PS_WallSlide>());
        states.Add(State.WallJump, ScriptableObject.CreateInstance<PS_WallJump>());
        states.Add(State.WallCling, ScriptableObject.CreateInstance<PS_WallCling>());
        states.Add(State.WallBound, ScriptableObject.CreateInstance<PS_WallBound>());
        states.Add(State.Attacking, ScriptableObject.CreateInstance<PS_Attacking>());
        states.Add(State.Hurt, ScriptableObject.CreateInstance<PS_Hurt>());
        states.Add(State.Aerial, ScriptableObject.CreateInstance<PS_AirAttack>());
        states.Add(State.AirDash, ScriptableObject.CreateInstance<PS_AirDash>());
        states.Add(State.Sliding, ScriptableObject.CreateInstance<PS_SlideDodge>());

        foreach (KeyValuePair<State, AbstractPlayerState> pair in states)
        {
            pair.Value.Init(anim, moves, this, character, hurtBehaviour);
            pair.Value.OnExit += StateTransition;
        }

        StateTransition(State.Falling);

    }

    public void RebindStateAnimations(string name)
    {
        foreach (KeyValuePair<State, AbstractPlayerState> pair in states)
        {
            pair.Value.BindStateAnimation(name);

        }
    }

    private void StateTransition(State obj)
    {
        AbstractPlayerState targetState = states[obj];

        if (targetState == currentState) { return; }

        if (currentState != null)
        {
            currentState.OnStateExit(actions);
        }
        currentState = targetState;
        currentState.OnStateEnter(actions);

    }

    public void Respawn()
    {
        StateTransition(State.Falling);
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
