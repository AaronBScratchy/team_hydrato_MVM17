using System;
using System.Collections.Generic;
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

    public abstract void OnStateEnter(PIA actions);
    public abstract void OnStateExit(PIA actions);

}
