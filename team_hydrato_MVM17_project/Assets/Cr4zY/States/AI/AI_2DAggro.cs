using System;
using UnityEngine;
public class AI_2DAggro : AbstractAIState
{
    public override void OnStateEnter()
    {
        stateMachine.onUpdate += Update;
        detector.attackAttempt += Attack;
        detector.onAggroEnd += Roam;
    }

    private void Roam()
    {
        onExit?.Invoke(AIState.ROAM);
    }

    private void Attack()
    {
        onExit?.Invoke(AIState.ATTACK);
    }
    private void Update()
    {
        nav.MoveTowards2D(detector.Target, anim);
    }

    public override void OnStateExit()
    {
        stateMachine.onUpdate -= Update;
        detector.attackAttempt -= Attack;
        detector.onAggroEnd -= Roam;
    }
}

