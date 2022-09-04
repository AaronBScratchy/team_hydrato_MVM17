using System;
using UnityEngine;

public class AI_Roam : AbstractAIState
{
    public override void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        name = "Roam";
        base.Init(_n, _s, _d, _h, _a);
    }
    public override void OnStateEnter()
    {
        nav.StartWalk();
        anim.SetFlip(!nav.FacingPosX);
        nav.onRest += Rest;
        detector.onAggroStart += Aggro;
        anim.PlayAnimation(clip, true);
        pain.onHurt += Hurt;
    }

    private void Hurt()
    {
        onExit?.Invoke(AIState.HURT);
    }

    private void Aggro()
    {
        onExit?.Invoke(AIState.AGGRO);
    }

    private void Rest()
    {
        onExit?.Invoke(AIState.IDLE);
    }

    public override void OnStateExit()
    {
        nav.onRest -= Rest;
        detector.onAggroStart -= Aggro;
        pain.onHurt -= Hurt;
    }
}
