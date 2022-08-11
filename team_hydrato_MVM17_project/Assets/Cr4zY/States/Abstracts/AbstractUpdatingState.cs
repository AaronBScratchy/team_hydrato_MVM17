﻿using System;

//Template class for State machine states that need to be updated on a fixed or per-frame basis
//Fixed and per-frame could be seperated but i'm lazy xD
internal abstract class AbstractUpdatingState : AbstractState
{
    public override void Init(PlayerAnimation _a, PlayerMovement _m, PlayerStateMachine _s)
    {
        base.Init(_a, _m, _s);
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
    protected abstract void OnUpdate();

    protected abstract void OnFixedUpdate();
}
