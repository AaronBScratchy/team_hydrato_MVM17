using System;
using UnityEngine;
public class AI_Hurt : AbstractAIState
{
    public override void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        name = "Hurt";
        base.Init(_n, _s, _d, _h, _a);
    }
    public override void OnStateEnter()
    {
        anim.PlayAnimation(clip, true);
        nav.landed += EndPain;

    }

    private void EndPain()
    {
        if (detector.PlayerPresence())
        {
            onExit?.Invoke(AIState.AGGRO);
            return;
        }
        onExit?.Invoke(AIState.ROAM);

    }

    public override void OnStateExit()
    {
        nav.landed -= EndPain;
    }
}

