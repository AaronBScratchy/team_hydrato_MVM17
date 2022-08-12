using System;
using UnityEngine;

public abstract class AbstractState : ScriptableObject
{

    protected PlayerAnimation anim;
    protected PlayerMovement movement;
    protected PlayerStateMachine stateMachine;
    public Action<State> OnExit;
    public virtual void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {

        anim = _a;
        movement = _m;
        stateMachine = _s;

    }

    public virtual void OnStateEnter(PIA actions)
    {
        Debug.Log(name);
    }
    public abstract void OnStateExit(PIA actions);

}
