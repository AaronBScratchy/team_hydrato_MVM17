using UnityEngine;
internal class PS_Jumpsquat : AbstractUpdatingState
{

    float timer;
    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        timer = 0.05f;
    }

    protected override void OnFixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer < 0)
        {
            TakeOff();
        }
    }

    protected override void OnUpdate()
    {
    }

    private void TakeOff()
    {
        OnExit?.Invoke(State.Jumping);
    }

}

