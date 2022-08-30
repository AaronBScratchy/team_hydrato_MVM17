using System;
using UnityEngine;
public class AI_Idle : AbstractAIState
{
    public override void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        name = "Idle";
        base.Init(_n, _s, _d, _h, _a);
    }
    public override void OnStateEnter()
    {
        nav.RestRB();
        nav.onRoam += Roam;
        anim.PlayAnimation(clip, true);
    }

    private void Roam()
    {
        onExit?.Invoke(AIState.ROAM);
    }

    public override void OnStateExit()
    {
        nav.onRoam -= Roam;
    }
}
