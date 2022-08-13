using UnityEngine;

internal class PS_Jump : AbstractUpdatingState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);

        name = "Jumping";
        clip = Resources.Load<SO_AnimationClip>("AnimationClips/Jump");
    }

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        anim.PlayAnimation(clip, false);
        movement.AddJump();
        movement.falling += Fall;

    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        movement.falling -= Fall;
    }

    protected override void OnFixedUpdate()
    {

        movement.SolveAerialVelocity();

    }

    protected override void OnUpdate()
    {
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }
}

