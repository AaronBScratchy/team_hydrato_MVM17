using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NavBoundType
{
    LEFT,
    RIGHT,
    ENCLOSURE,
    ENTRY
}
public class NavBound : MonoBehaviour
{
    [SerializeField] NavBoundType type;
    public Action<NavBoundType, AINavigator> hit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<AINavigator>(out AINavigator nav))
        {
            hit?.Invoke(type, nav);
        }
    }
}
