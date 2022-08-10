using System;

//Template class for State machine states that need to be updated on a fixed or per-frame basis
//Fixed and per-frame could be seperated but i'm lazy xD
internal abstract class AbstractUpdatingState : AbstractState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);

        _s.onFixedUpdate += OnFixedUpdate;
        _s.onUpdate += OnUpdate;
    }

    protected abstract void OnUpdate();

    protected abstract void OnFixedUpdate();
}
