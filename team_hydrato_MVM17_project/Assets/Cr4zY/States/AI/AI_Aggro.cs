﻿using UnityEngine;
using System;

public class AI_Aggro: AbstractAIState
{
    public override void BindAnimation(string animationName)
    {
        clip = Resources.Load<AnimationClip>("AnimationClips/Enemy/" + animationName + "/Roam");
    }
    public override void OnStateEnter()
    {
        stateMachine.onUpdate += Update;
        detector.attackAttempt += Attack;
        detector.onAggroEnd += Doubt;
    }

    private void Doubt()
    {
        onExit?.Invoke(AIState.SUS);
    }

    private void Attack()
    {
        onExit?.Invoke(AIState.ATTACK);
    }

    public override void OnStateExit()
    {
        detector.attackAttempt -= Attack;
        stateMachine.onUpdate -= Update;
        detector.onAggroEnd -= Doubt;
    }

    private void Update()
    {
        nav.MoveTowards(detector.Target, anim);
    }
}

