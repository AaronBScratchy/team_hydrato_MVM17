using System;
using UnityEngine;

public abstract class AbstractPlayerState : ScriptableObject
{
    protected AnimationClip clip;
    protected CustomAnimationController anim;
    protected CharacterMovement movement;
    protected CharacterStateMachine stateMachine;
    protected Character character;
    public Action<State> OnExit;

    //Initialiser references relevant monobehaviour components
    public virtual void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, Character _c)
    {
        anim = _a;
        movement = _m;
        stateMachine = _s;
        character = _c;

        BindStateAnimation(_c.ToString());
    }

    //Behaviour to run when the state starts
    public virtual void OnStateEnter(PIA actions)
    {
        //Debug.Log(name);
    }

    //Behaviour to run when the state stops running
    public abstract void OnStateExit(PIA actions);

    public void BindStateAnimation(string currentChar)
    {
        clip = Resources.Load<AnimationClip>("AnimationClips/Player/" + currentChar + "/" + name);
    }

}
