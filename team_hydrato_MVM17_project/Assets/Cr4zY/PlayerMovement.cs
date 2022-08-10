using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D currentWall, currentGround;
    public Action landed, falling, wallLeft, wallTouch;
    private bool lastLeft;
    private int MaxJumps;
    private int jumpsLeft;

    [SerializeField] float maxSpeed = 15;
    [SerializeField] float maxAirSpeed = 10;
    [SerializeField] float acceleration = 62.5f;
    [SerializeField] float airAceleration = 47.5f;
    [SerializeField] float jumpForce = 45;
    [SerializeField] float gravityScale = 90;
    //[SerializeField] float 
    //[SerializeField] float

    InputAction MoveX;

    public bool CanJump { get { return jumpsLeft > 0; } }

    public void Init(PIA pia)
    {

        rb = GetComponent<Rigidbody2D>();
        lastLeft = false;

        MoveX = pia.World.Horizontal;

    }


    public void SolveGroundedVelocity()
    {
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;



        rb.velocity = new(xCom, yCom);

    }

    public void SolveAerialVelocity()
    {
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;



        rb.velocity = new(xCom, yCom);

    }

    public void OnLand()
    {
        jumpsLeft = MaxJumps;
        landed?.Invoke();
    }

    public void RestRB()
    {
        rb.velocity = Vector2.zero;
    }

    public void AddJump()
    {
        if (jumpsLeft > 0)
        {
            jumpsLeft--;
            rb.velocity += Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector2.Dot(collision.GetContact(collision.contactCount - 1).normal, Vector2.up) > 0.85f)
        {
            landed?.Invoke();
            return;
        }

        if (Mathf.Abs(Vector2.Dot(collision.GetContact(collision.contactCount - 1).normal, Vector2.right)) > 0.85f)
        {
            currentWall = collision.collider;
            wallTouch?.Invoke();
            return;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider == currentGround)
        {
            currentGround = null;
            falling?.Invoke();
            return;
        }

        if(collision.collider == currentWall)
        {
            currentWall = null;
            wallLeft?.Invoke();
            return;
        }
    }

}
