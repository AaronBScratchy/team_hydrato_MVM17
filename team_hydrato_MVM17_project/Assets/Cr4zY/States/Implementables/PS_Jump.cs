
internal class PS_Jump : AbstractUpdatingState
{
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
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

