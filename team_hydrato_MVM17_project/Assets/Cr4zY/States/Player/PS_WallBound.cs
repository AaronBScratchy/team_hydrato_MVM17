using UnityEngine;

public class PS_WallBound : AbstractUpdatingPS
{
    private Rigidbody2D rb;
    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c)
    {
        name = "WallBound";
        base.Init(_a, _m, _s, _c);
        rb = _a.GetComponent<Rigidbody2D>();
    }

    public override void OnStateEnter(PIA actions)
    {
        base.OnStateEnter(actions);
        movement.wallLeft += Fall;

        if (movement.CanBound)
        {
            movement.ToggleGravity();
            anim.PlayAnimation(clip, false);
            anim.animOver += movement.PerformWallBound;
            return;
        }
        movement.RestRB();
        Fall();

    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }

    private void ClingWall()
    {
        OnExit?.Invoke(State.WallCling);
    }

    public override void OnStateExit(PIA actions)
    {
        base.OnStateExit(actions);
        anim.animOver -= movement.PerformWallBound;
        movement.wallLeft -= Fall;
        anim.animOver = null;
    }

    protected override void OnUpdate()
    {
    }

    protected override void OnFixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            ClingWall();
        }
    }
}