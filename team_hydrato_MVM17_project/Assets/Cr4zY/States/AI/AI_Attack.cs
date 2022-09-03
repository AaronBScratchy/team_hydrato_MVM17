
using System;

public class AI_Attack : AbstractAIState
{
    private AttackingAnimationClip attack;
    public override void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h, CustomAnimationController _a)
    {
        name = "Attack";
        base.Init(_n, _s, _d, _h, _a);
    }

    public override void BindAnimation(string animationName)
    {
        base.BindAnimation(animationName);
        attack = clip as AttackingAnimationClip;
    }
    public override void OnStateEnter()
    {
        nav.RestRB();
        anim.PlayAttackAnimation(attack, false);
        anim.animOver += EndAttack;

    }

    private void EndAttack()
    {
        onExit?.Invoke(AIState.AGGRO);
    }

    public override void OnStateExit()
    {
        anim.animOver -= EndAttack;
    }
}

