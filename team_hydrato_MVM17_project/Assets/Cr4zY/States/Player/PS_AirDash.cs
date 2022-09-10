using System;
using UnityEngine;
public class PS_AirDash : AbstractPlayerState
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "AirDash";
        base.Init(_a, _m, _s, _c, _h);
    }

    public override void OnStateEnter(PIA actions)
    {
        anim.SetFlip(movement.StartDash());
        anim.PlayAnimation(clip, false);
        hurtBehaviour.ToggleIB();
        movement.dashEnd += OnDashEnd;
        movement.wallTouch += WallSlide;
    }

    private void WallSlide()
    {
        OnExit?.Invoke(State.WallSlide);
    }

    private void OnDashEnd()
    {
        movement.RestRB();
        OnExit?.Invoke(movement.ResolveState());
    }

    public override void OnStateExit(PIA actions)
    {
        hurtBehaviour.ToggleIB();
        movement.dashEnd -= OnDashEnd;
        movement.wallTouch-= WallSlide;
    }
}
