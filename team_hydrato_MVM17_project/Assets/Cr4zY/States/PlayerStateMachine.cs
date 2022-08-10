using System;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle,
}

public class PlayerStateMachine : MonoBehaviour
{
    public Action onFixedUpdate, onUpdate;

    AbstractState[] states;

    public void Init()
    {

        states = new AbstractState[] {

        };


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        


    }
}
