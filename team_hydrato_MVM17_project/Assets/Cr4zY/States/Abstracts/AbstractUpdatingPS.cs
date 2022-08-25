
//Template class for State machine states that need to be updated on a fixed or per-frame basis
//Fixed and per-frame could be seperated but i'm lazy xD
public abstract class AbstractUpdatingPS : AbstractPlayerState
{
    //Initialises the state
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c)
    {
        base.Init(_a, _m, _s, _c);
    }

    public override void OnStateEnter(PIA actions)
    {
        stateMachine.onFixedUpdate += OnFixedUpdate;
        stateMachine.onUpdate += OnUpdate;
    }
    public override void OnStateExit(PIA actions)
    {
        stateMachine.onFixedUpdate -= OnFixedUpdate;
        stateMachine.onUpdate -= OnUpdate;
    }

    //Behaviour to run per frame
    protected abstract void OnUpdate();

    //Behaviour to run per fixed update
    protected abstract void OnFixedUpdate();
}
