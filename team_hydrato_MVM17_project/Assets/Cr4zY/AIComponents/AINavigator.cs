using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINavigator : MonoBehaviour
{
    private Action boundHit;
    private Rigidbody rb;
    [SerializeField] private bool intentRight, constantMover;
    [SerializeField] private float restTimeMin, restTimeMax, moveTimeMin, moveTimeMax, turnFreqMin, turnFreqMax, moveSpeed;
    private bool moving;
    public void Init()
    {
    }
    private void Awake()
    {
    }

    private void Turn()
    {
        Turn(!intentRight);
    }
    private void Turn(bool right)
    {
        intentRight = right;

        if (!moving)
        {
            return;
        }
        rb.velocity = new Vector2(intentRight ? moveSpeed : -moveSpeed, 0);

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
