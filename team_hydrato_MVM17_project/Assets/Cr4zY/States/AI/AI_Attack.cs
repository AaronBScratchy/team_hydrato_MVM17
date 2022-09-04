
using System;

public class AI_Attack : AbstractAIState
{
    private AttackingAnimationClip attack;
    public Action buffer;
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
        buffer += Aggro;
        detector.onAggroEnd += BufferRoam;
        detector.onAggroStart += BufferAggro;
        pain.onHurt += Hurt;
    }

    private void Hurt()
    {
        onExit?.Invoke(AIState.HURT);
    }
    private void BufferRoam()
    {
        buffer -= Aggro;
        buffer += Roam;
    }

    private void Roam()
    {
        buffer -= Roam;
        onExit?.Invoke(AIState.ROAM);
    }

    private void Aggro()
    {
        buffer -= Aggro;
        onExit?.Invoke(AIState.AGGRO);
    }

    private void BufferAggro()
    {
        buffer -= Roam;
        buffer += Aggro;
    }

    private void EndAttack()
    {
        buffer?.Invoke();
    }

    public override void OnStateExit()
    {
        anim.animOver -= EndAttack;
        detector.onAggroEnd -= BufferRoam;
        detector.onAggroStart -= BufferAggro;
        pain.onHurt -= Hurt;
    }
}

