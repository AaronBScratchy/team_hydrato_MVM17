using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterCheckpointer : MonoBehaviour
{
    private CharacterMovement moves;
    private Vector2 checkPoint;

    public Action onDeath;
    public void Init(CharacterMovement _m)
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
