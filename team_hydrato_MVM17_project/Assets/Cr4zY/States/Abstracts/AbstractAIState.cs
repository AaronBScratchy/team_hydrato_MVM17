using UnityEngine;
using System;
public abstract class AbstractAIState : ScriptableObject
{
    protected AIHurtBehaviour hurt;
    protected AIDetector detector;
    protected AIStateMachine stateMachine;
    protected AINavigator nav;
    protected CustomAnimationController anim;

    protected AnimationClip clip;
    public Action<AIState> onExit;
    public virtual void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        hurt = _h;
        detector = _d;
        stateMachine = _s;
        nav = _n;
        anim = _a;
    }
    public abstract void OnStateEnter();

    public abstract void OnStateExit();

    public virtual void BindAnimation(string animationName)
    {

        clip = Resources.Load<AnimationClip>("AnimationClips/Enemy/" + animationName + "/" + name);

    }
}
