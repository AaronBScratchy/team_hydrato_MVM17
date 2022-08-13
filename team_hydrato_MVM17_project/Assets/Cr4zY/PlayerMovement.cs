using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D currentWall, currentGround;
    public Action falling, wallLeft, wallTouch, turn, turnComplete;
    public Action<bool> landed;
    private bool FacingPosX;
    public bool Moving { get { return rb.velocity != Vector2.zero; } }

    private int MaxJumps;
    private int jumpsLeft;

    [SerializeField] float maxSpeed = 15;
    [SerializeField] float maxAirSpeed = 10;
    [SerializeField] float acceleration = 62.5f;
    [SerializeField] float airAcceleration = 47.5f;
    [SerializeField] float jumpForce = 45;
    [SerializeField] float gravityScale = 90;
    //[SerializeField] float 
    //[SerializeField] float

    InputAction MoveX;

    public bool CanJump { get { return jumpsLeft > 0; } }

    public void Init(PIA pia)
    {
        MaxJumps = 1;
        jumpsLeft = 0;
        rb = GetComponent<Rigidbody2D>();
        FacingPosX = true;

        MoveX = pia.World.Horizontal;

    }

    public void Decelerate()
    {
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;
        if (xCom == 0)
        {
            return;
        }
        xCom -= (xCom > 0 ? 1.75f : -1.75f) * acceleration * Time.fixedDeltaTime;
        xCom = FacingPosX ? Mathf.Max(xCom, 0) : Mathf.Min(xCom, 0);
        rb.velocity = new(xCom, yCom);

    }

    public void SolveGroundedVelocity()
    {
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;

        xCom += MoveX.ReadValue<float>() * acceleration * Time.fixedDeltaTime;
        xCom = (FacingPosX ? Mathf.Min(xCom, maxSpeed) : Mathf.Max(xCom, -maxSpeed));
        if (rb.velocity.x != 0)
        {
            if (FacingPosX ^ xCom > 0)
            {
                turn?.Invoke();
                return;
            }
        }

        FacingPosX = MoveX.ReadValue<float>() != 0 ? (MoveX.ReadValue<float>() > 0) : FacingPosX;

        rb.velocity = new(xCom, yCom);

    }

    public void SolveAerialVelocity()
    {
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;

        bool rising = yCom > 0;


        xCom += MoveX.ReadValue<float>() * airAcceleration * Time.fixedDeltaTime;
        xCom = (FacingPosX ? Mathf.Min(xCom, maxAirSpeed) : Mathf.Max(xCom, -maxAirSpeed));
        yCom -= gravityScale * Time.fixedDeltaTime;

        rb.velocity = new(xCom, yCom);

        if (rising && rb.velocity.y < 0)
        {
            falling?.Invoke();
        }

    }

    public void Turn()
    {
        FacingPosX = !FacingPosX;
    }

    public void TurnToPosX(bool posX)
    {
        FacingPosX = posX;
    }
    public void ApplyTurn()
    {

        if (Mathf.Abs(rb.velocity.x) < maxSpeed * 0.2f)
        {
            rb.velocity = 0.5f * maxSpeed * (FacingPosX ? Vector2.right : Vector2.left);
            turnComplete?.Invoke();
            return;
        }
        Decelerate();

    }

    public void OnLand()
    {
        jumpsLeft = MaxJumps;
        landed?.Invoke(MoveX.ReadValue<float>() != 0);
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
            OnLand();
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
        if (collision.collider == currentGround)
        {
            currentGround = null;
            falling?.Invoke();
            return;
        }

        if (collision.collider == currentWall)
        {
            currentWall = null;
            wallLeft?.Invoke();
            return;
        }
    }
}