using System;
using UnityEngine;

public class AI_Sus : AbstractAIState
{
    public override void BindAnimation(string animationName)
    {
        clip = Resources.Load<AnimationClip>("AnimationClips/Enemy/" + animationName + "/Idle");
    }
    public override void OnStateEnter()
    {
        nav.RestRB();
        anim.PlayAnimation(clip, true);
        detector.StartDoubtTimer();
        detector.doubtsCleared += Roam;
        detector.onAggroStart += Aggro;
    }

    private void Aggro()
    {
        onExit?.Invoke(AIState.AGGRO);
    }

    private void Roam()
    {
        onExit?.Invoke(AIState.ROAM);
    }

    public override void OnStateExit()
    {
        detector.doubtsCleared -= Roam;
        detector.onAggroStart -= Aggro;
    }
}
