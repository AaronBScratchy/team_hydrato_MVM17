using System;
using UnityEngine;

public abstract class AbstractPlayerState : ScriptableObject
{
    protected AnimationClip clip;
    protected CustomAnimationController anim;
    protected CharacterMovement movement;
    protected CharacterStateMachine stateMachine;
    protected CharacterSelect selector;
    public Action<State> OnExit;

    //Initialiser references relevant monobehaviour components
    public virtual void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c)
    {
        movement = _m;
        stateMachine = _s;
        selector = _c;
        anim = _a;

        BindStateAnimation(selector.CurrentCharacter.ToString());
    }

    //Behaviour to run when the state starts
    public abstract void OnStateEnter(PIA actions);

    //Behaviour to run when the state stops running
    public abstract void OnStateExit(PIA actions);

    public void BindStateAnimation(string currentChar)
    {
        clip = Resources.Load<AnimationClip>("AnimationClips/Player/" + currentChar + "/" + name);
    }

}
