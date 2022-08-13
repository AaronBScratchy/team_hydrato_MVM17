using UnityEngine;
internal class PS_Jumpsquat : AbstractState
{

    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);

        name = "Jump squat";
        clip = Resources.Load<SO_AnimationClip>("AnimationClips/JumpSquat");
    }

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        anim.PlayAnimation(clip, false);
        anim.animOver += TakeOff;
    }

    public override void OnStateExit(PIA actions)
    {
        anim.animOver -= TakeOff;
    }

    private void TakeOff()
    {
        OnExit?.Invoke(State.Jumping);
    }

}