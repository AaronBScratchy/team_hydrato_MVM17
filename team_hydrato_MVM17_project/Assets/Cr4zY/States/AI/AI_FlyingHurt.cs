using System;

public class AI_FlyingHurt : AbstractAIState
{
    public override void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        name = "Hurt";
        base.Init(_n, _s, _d, _h, _a);
    }

    public override void OnStateEnter()
    {
        anim.PlayAnimation(clip, false);
        anim.animOver += Relief;

    }

    private void Relief()
    {
        nav.RestRB();
        onExit?.Invoke(detector.PlayerPresence() ? AIState.AGGRO : AIState.ROAM);
    }

    public override void OnStateExit()
    {
        anim.animOver -= Relief;
    }
}

