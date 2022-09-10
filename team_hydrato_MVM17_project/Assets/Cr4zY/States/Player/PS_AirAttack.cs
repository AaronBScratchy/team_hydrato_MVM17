using System;
using UnityEngine;
public class PS_AirAttack : AbstractPlayerState
{
    AttackingAnimationClip attack;
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "Aerial";
        base.Init(_a, _m, _s, _c, _h);
    }

    public override void BindStateAnimation(string currentChar)
    {
        attack = Resources.Load<AttackingAnimationClip>("AnimationClips/Player/Attacks/" + currentChar + "/" + name);
    }

    public override void OnStateEnter(PIA actions)
    {
        anim.PlayAttackAnimation(attack, false);
        anim.animOver += Fall;
        movement.landed += Land;
    }

    private void Land(bool moving)
    {
        if (moving)
        {
            OnExit?.Invoke(State.Running);
            return;
        }
        OnExit?.Invoke(State.Idle);
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    public override void OnStateExit(PIA actions)
    {
        movement.landed -= Land;
        anim.animOver -= Fall;
    }
}
