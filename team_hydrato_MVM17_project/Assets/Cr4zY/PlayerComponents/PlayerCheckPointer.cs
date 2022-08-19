using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerCheckPointer : MonoBehaviour
{
    private PlayerMovement moves;
    private Vector2 checkPoint;

    public Action onDeath;
    public void Init(PlayerMovement _m)
    {
        moves = _m;
        checkPoint = GetComponent<Rigidbody2D>().position;
        onDeath += Respawn;
    }

    private void Respawn()
    {
        moves.Teleport(checkPoint);
    }



}
