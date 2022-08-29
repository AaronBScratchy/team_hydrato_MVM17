using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavBoundCollection : MonoBehaviour
{
    [SerializeField] List<AINavigator> populus;
    private void Awake()
    {
        NavBound[] collection = GetComponentsInChildren<NavBound>();

        foreach(NavBound bound in collection)
        {
            bound.hit += OnBoundHit;
        }

    }

    private void OnBoundHit(NavBoundType boundType, AINavigator ai)
    {
        if(populus.Contains(ai))
        {
            ai.HitBound(boundType);
        }
    }
}
