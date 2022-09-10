using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINavigator : MonoBehaviour
{
    public Action boundHit, onRoam, onRest, landed;
    private Rigidbody2D rb;
    [SerializeField] private bool intentRight, constantMover;
    public bool FacingPosX { get { return intentRight; } }

    [SerializeField] private float restTimeMin, restTimeMax, moveTimeMin, moveTimeMax, turnFreqMin, turnFreqMax, moveSpeed, gravScale;
    private bool moving;
    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Invoke(nameof(Roam), UnityEngine.Random.Range(restTimeMin, restTimeMax));
    }

    public void MoveTowards2D(Vector2 target, CustomAnimationController anim)
    {
        CancelInvoke();

        Vector2 targetDir = (target - rb.position).normalized;

        rb.velocity = targetDir * moveSpeed;
        anim.SetFlip(rb.velocity.x < 0);

    }

    public void MoveTowards(Vector2 target, CustomAnimationController anim)
    {
        CancelInvoke();

        bool targAhead = target.x - rb.position.x > 0 == rb.velocity.x > 0;
        targAhead &= rb.velocity != Vector2.zero;
        if (targAhead)
        {
            return;
        }

        anim.SetFlip(!((target - rb.position).x > 0));
        rb.velocity = ((target - rb.position).x > 0 ? Vector2.right : Vector2.left) * moveSpeed;

    }

    private void Turn()
    {
        Turn(!intentRight);
    }
    private void Turn(bool right)
    {
        GetComponent<CustomAnimationController>().SetFlip(!right);
        intentRight = right;

        if (!moving)
        {
            return;
        }
        rb.velocity = new(intentRight ? moveSpeed : -moveSpeed, 0);

        CancelInvoke(nameof(Turn));
        Invoke(nameof(Turn), UnityEngine.Random.Range(1 / turnFreqMax, 1 / turnFreqMin));

    }

    public void StartWalk()
    {
        rb.velocity = new(intentRight ? moveSpeed : -moveSpeed, 0);
        moving = true;
    }

    private void Idle()
    {
        CancelInvoke(nameof(Turn));
        onRest?.Invoke();

        Invoke(nameof(Roam), UnityEngine.Random.Range(restTimeMin, restTimeMax));
    }

    private void Roam()
    {
        onRoam?.Invoke();

        Invoke(nameof(Turn), UnityEngine.Random.Range(1 / turnFreqMax, 1 / turnFreqMin));

        if (constantMover)
        {
            return;
        }

        Invoke(nameof(Idle), UnityEngine.Random.Range(moveTimeMin, moveTimeMax));

    }

    public void RestRB()
    {
        rb.velocity = Vector2.zero;
        moving = false;
    }

    public void HitBound(NavBoundType boundType)
    {
        if (!rb.isKinematic)
        {
            return;
        }

        GetComponent<AIDetector>().StopAggro();

        boundHit += boundType switch
        {
            NavBoundType.LEFT => LeftBoundHit,
            NavBoundType.RIGHT => RightBoundHit,
            NavBoundType.ENCLOSURE => EnclosureHit,
            NavBoundType.ENTRY => throw new NotImplementedException(),
            _ => BoundNull,
        };
        boundHit?.Invoke();
        boundHit = null;
    }

    private void EnclosureHit()
    {
        GetComponent<CustomAnimationController>().SetFlip(rb.velocity.x > 0);
        rb.velocity *= -1;
    }

    private void LeftBoundHit()
    {
        Turn(true);
    }
    private void RightBoundHit()
    {
        Turn(false);
    }
    private void BoundNull()
    { }

    private void Land()
    {
        RestRB();
        landed?.Invoke();
        ToggleGravity(false);
    }

    public void Launch(Vector2 launcher, float power)
    {
        CancelInvoke();
        RestRB();
        ToggleGravity(true);
        rb.velocity = launcher * power;
    }
    public void KinematicLaunch(Vector2 launcher, float power)
    {
        CancelInvoke();
        RestRB();
        rb.velocity = launcher * power;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.85f)
        {
            Land();
            return;
        }
    }


    public void RW2D_Roam()
    {

        rb.velocity = new Vector2((UnityEngine.Random.value * 2) - 1, (UnityEngine.Random.value * 2) - 1).normalized * moveSpeed;
        moving = true;

        if (constantMover)
        {
            Invoke(nameof(RW2D_Roam), UnityEngine.Random.Range(moveTimeMin, moveTimeMax));
            return;
        }

        Invoke(nameof(RW2D_Rest), UnityEngine.Random.Range(moveTimeMin, moveTimeMax));

    }

    public void ToggleGravity()
    {
        ToggleGravity(rb.gravityScale == 0);
    }

    public void ToggleGravity(bool on)
    {
        rb.gravityScale = on ? gravScale : 0;
    }

    private void RW2D_Rest()
    {
        CancelInvoke(nameof(RW2D_Roam));
        RestRB();
        onRest?.Invoke();
    }

}
