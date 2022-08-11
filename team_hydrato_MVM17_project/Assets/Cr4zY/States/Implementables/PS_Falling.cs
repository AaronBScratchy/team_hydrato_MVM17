
internal class PS_Falling : AbstractUpdatingState
{
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        movement.landed += Land;
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        movement.landed -= Land;
    }

    protected override void OnFixedUpdate()
    {
        movement.SolveAerialVelocity();
    }

    protected override void OnUpdate()
    {
    }

    private void Land(bool movementIntended)
    {
        if (movementIntended)
        {
            OnExit?.Invoke(State.Running);
            return;
        }
        OnExit?.Invoke(State.Idle);
    }
}

