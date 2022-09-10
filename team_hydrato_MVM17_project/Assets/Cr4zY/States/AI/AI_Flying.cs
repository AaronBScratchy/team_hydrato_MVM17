using UnityEngine;
using System;
public class AI_Flying : AbstractAIState
{
    public override void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        name = "Flying";
        base.Init(_n, _s, _d, _h, _a);
    }
    public override void OnStateEnter()
    {
        anim.PlayAnimation(clip, true);
        nav.RW2D_Roam();
        detector.onAggroStart += Aggro;
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

    public override void OnStateExit()
    {
        detector.onAggroStart -= Aggro;
        pain.onHurt -= Hurt;
    }
}
