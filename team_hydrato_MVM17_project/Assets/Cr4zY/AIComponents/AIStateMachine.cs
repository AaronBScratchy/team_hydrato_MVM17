using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    IDLE,
    ROAM,
    AGGRO,
    ATTACK,
    SUS
}
public class AIStateMachine : MonoBehaviour
{
    private Dictionary<AIState, AbstractAIState> states = new();
    public Action onUpdate, onFixedUpdate;
    private AbstractAIState currentState;

    public void Init(AIDetector detector, AIHurtBehaviour hurt, AINavigator nav, CustomAnimationController anim, string animationName)
    {
        states.Add(AIState.ROAM, ScriptableObject.CreateInstance<AI_Roam>());
        states.Add(AIState.IDLE, ScriptableObject.CreateInstance<AI_Idle>());
        states.Add(AIState.AGGRO, ScriptableObject.CreateInstance<AI_Aggro>());
        states.Add(AIState.ATTACK, ScriptableObject.CreateInstance<AI_Attack>());
        states.Add(AIState.SUS, ScriptableObject.CreateInstance<AI_Sus>());

        foreach (KeyValuePair<AIState, AbstractAIState> pair in states)
        {
            pair.Value.Init(nav, this, detector, hurt, anim);
            pair.Value.BindAnimation(animationName);
        }

        StateTransition(AIState.IDLE);
    }

    private void StateTransition(AIState state)
    {
        AbstractAIState target = states[state];

        if (target == currentState)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.OnStateExit();
            currentState.onExit -= StateTransition;
        }
        currentState = target;
        currentState.OnStateEnter();
        currentState.onExit += StateTransition;
    }

    private void Update()
    {
        onUpdate?.Invoke();
    }

    private void FixedUpdate()
    {
        onFixedUpdate?.Invoke();
    }
}
