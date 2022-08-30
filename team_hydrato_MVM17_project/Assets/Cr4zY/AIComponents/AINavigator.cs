using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINavigator : MonoBehaviour
{
    public Action boundHit, onRoam, onRest;
    private Rigidbody2D rb;
    [SerializeField] private bool intentRight, constantMover;
    [SerializeField] private float restTimeMin, restTimeMax, moveTimeMin, moveTimeMax, turnFreqMin, turnFreqMax, moveSpeed;
    private bool moving;
    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke(nameof(Roam), UnityEngine.Random.Range(restTimeMin, restTimeMax));
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
        boundHit += boundType switch
        {
            NavBoundType.LEFT => LeftBoundHit,
            NavBoundType.RIGHT => RightBoundHit,
            NavBoundType.ENTRY => throw new NotImplementedException(),
            _ => BoundNull,
        };
        boundHit?.Invoke();
        boundHit = null;
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
}
