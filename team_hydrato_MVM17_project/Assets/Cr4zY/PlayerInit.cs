using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{

    public void Init()
    {
        PIA inputActions = new();
        inputActions.World.Jump.Enable();
        inputActions.World.Horizontal.Enable();

        PlayerAnimation anim = GetComponent<PlayerAnimation>();
        PlayerMovement moves = GetComponent<PlayerMovement>();
        PlayerStateMachine states = GetComponent<PlayerStateMachine>();
        anim.Init();
        moves.Init(inputActions);
        states.Init(anim,moves,inputActions);
        Destroy(this);
    }

}
