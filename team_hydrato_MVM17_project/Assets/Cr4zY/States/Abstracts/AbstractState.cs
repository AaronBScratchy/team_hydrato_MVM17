using System;
using UnityEngine;

public abstract class AbstractState : ScriptableObject
{
    protected AnimationClip clip;
    protected PlayerAnimation anim;
    protected PlayerMovement movement;
    protected PlayerStateMachine stateMachine;
    public Action<State> OnExit;

    //Initialiser references relevant monobehaviour components
    public virtual void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        anim = _a;
        movement = _m;
        stateMachine = _s;
    }

    //Behaviour to run when the state starts
    public virtual void OnStateEnter(PIA actions)
    {
        //Debug.Log(name);
    }
    
    //Behaviour to run when the state stops running
    public abstract void OnStateExit(PIA actions);

}
