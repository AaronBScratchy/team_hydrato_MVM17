public class PS_Hurt : AbstractPlayerState
{
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        name = "Hurt";
        base.Init(_a, _m, _s, _c, _h);
    }
    public override void OnStateEnter(PIA actions)
    {

        anim.PlayAnimation(clip, false);
        anim.animOver += ShakeItOff;

    }

    private void ShakeItOff()
    {
        anim.animOver -= ShakeItOff;
        OnExit(movement.ResolveState());
    }

    public override void OnStateExit(PIA actions)
    {
    }
}
