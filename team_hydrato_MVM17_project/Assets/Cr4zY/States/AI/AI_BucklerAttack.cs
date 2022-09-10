using System;
using System.Collections.Generic;
using UnityEngine;
public class AI_BucklerAttack : AbstractAIState
{
    private AnimationClip bPart;
    private Vector2 target;
    public override void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        name = "Attack";
        base.Init(_n, _s, _d, _h, _a);
    }

    public override void BindAnimation(string animationName)
    {
        clip = Resources.Load<AnimationClip>("AnimationClips/Enemy/" + animationName + "/" + name + "A");
        bPart = Resources.Load<AnimationClip>("AnimationClips/Enemy/" + animationName + "/" + name + "B");
    }

    public override void OnStateEnter()
    {
        target = detector.Target;
        anim.PlayAnimation(clip, false);
        nav.KinematicLaunch((target - nav.GetComponent<Rigidbody2D>().position).normalized, -0.5f);
        anim.animOver += DoAttackLaunch;
        detector.onAggroEnd += CancelAttack;
    }

    private void CancelAttack()
    {
        nav.RestRB();
        detector.StartRecovery();
        onExit?.Invoke(AIState.ROAM);
    }

    private void DoAttackLaunch()
    {
        anim.animOver -= DoAttackLaunch;
        nav.KinematicLaunch((target-nav.GetComponent<Rigidbody2D>().position).normalized,15);
        anim.PlayAnimation(bPart, false);
        anim.animOver += EndAttack;
    }

    private void EndAttack()
    {
        nav.RestRB();
        detector.StartRecovery();
        onExit?.Invoke(detector.PlayerPresence() ? AIState.AGGRO : AIState.IDLE);
    }

    public override void OnStateExit()
    {
        anim.animOver = null;
        detector.onAggroEnd -= CancelAttack;
    }
}

