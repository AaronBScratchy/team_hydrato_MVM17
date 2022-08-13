using System;
using UnityEngine;
using UnityEngine.InputSystem;

//Player physics and movement controller
public class PlayerMovement : MonoBehaviour
{
    //Rigidbody reference
    private Rigidbody2D rb;

    //Last contacted surfaces references
    private Collider2D currentWall, currentGround;

    //Actions for movement events
    public Action falling, wallLeft, wallTouch, turn, turnComplete;
    public Action<bool> landed;

    //Moving to the right
    private bool FacingPosX;

    //Moving at all
    public bool Moving { get { return rb.velocity != Vector2.zero; } }

    //Stats and counters
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

    //Horizontal input reference
    InputAction MoveX;

    public bool CanJump { get { return jumpsLeft > 0; } }

    //Initialiser, sets values that were previously null
    public void Init(PIA pia)
    {
        MaxJumps = 1;
        jumpsLeft = 0;
        rb = GetComponent<Rigidbody2D>();
        FacingPosX = true;

        MoveX = pia.World.Horizontal;

    }

    //Per frame reduction of speed
    public void Decelerate()
    {
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;
        if (xCom == 0)
        {
            //early exit at 0 horizontal speed
            return;
        }

        //Apply deceleration and cap at 0
        xCom -= (xCom > 0 ? 1.75f : -1.75f) * acceleration * Time.fixedDeltaTime;
        xCom = FacingPosX ? Mathf.Max(xCom, 0) : Mathf.Min(xCom, 0);

        //Update velocity 
        rb.velocity = new(xCom, yCom);

    }

    //Per frame velocity calculations for the ground
    public void SolveGroundedVelocity()
    {
        //Cache velocity components
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;

        //apply horizontal acceleration
        xCom += MoveX.ReadValue<float>() * acceleration * Time.fixedDeltaTime;
        xCom = (FacingPosX ? Mathf.Min(xCom, maxSpeed) : Mathf.Max(xCom, -maxSpeed));

        //Catch turn attempt logic
        if (rb.velocity.x != 0)
        {
            if (FacingPosX ^ xCom > 0)
            {
                turn?.Invoke();
                return;
            }
        }

        //Update intended direction - this can be moved to somewhere better, doesn't need to run per frame
        FacingPosX = MoveX.ReadValue<float>() != 0 ? (MoveX.ReadValue<float>() > 0) : FacingPosX;

        //Update velocity
        rb.velocity = new(xCom, yCom);

    }

    //Per frame velocity calculations for in air
    //Same as on the ground but:
    // - no turn catch
    // - added application of gravity
    public void SolveAerialVelocity()
    {

        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;

        xCom += MoveX.ReadValue<float>() * airAcceleration * Time.fixedDeltaTime;
        xCom = (FacingPosX ? Mathf.Min(xCom, maxAirSpeed) : Mathf.Max(xCom, -maxAirSpeed));

        //gravity applied here
        yCom -= gravityScale * Time.fixedDeltaTime;

        rb.velocity = new(xCom, yCom);

        //Fall catch logic
        if (rb.velocity.y < 0)
        {
            falling?.Invoke();
        }

    }

    //Toggle intended direction
    public void Turn()
    {
        FacingPosX = !FacingPosX;
    }

    //Set intended direction
    public void TurnToPosX(bool posX)
    {
        FacingPosX = posX;
    }

    //Per frame deceleration for change in direction
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

    //Resets air action counters/perms on landing
    public void OnLand()
    {
        jumpsLeft = MaxJumps;
        landed?.Invoke(MoveX.ReadValue<float>() != 0);

        //Catch case for landing with movement intent - adds velocity to counter friction on landing halting the player
        if(MoveX.ReadValue<float>() == 0)
        {
            return;
        }
        rb.velocity = MoveX.ReadValue<float>() * Vector2.right * maxSpeed;
    }

    //Halts rigidbody
    public void RestRB()
    {
        rb.velocity = Vector2.zero;
    }

    //Adds vertical velocity for a jump
    public void AddJump()
    {
        if (jumpsLeft > 0)
        {
            jumpsLeft--;
            rb.velocity += Vector2.up * jumpForce;
        }
    }

    //Collision logic
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Catching horizontal surface - landing
        if (Vector2.Dot(collision.GetContact(collision.contactCount - 1).normal, Vector2.up) > 0.85f)
        {
            OnLand();
            return;
        }

        //Catching erected surface - walls
        if (Mathf.Abs(Vector2.Dot(collision.GetContact(collision.contactCount - 1).normal, Vector2.right)) > 0.85f)
        {
            currentWall = collision.collider;
            wallTouch?.Invoke();
            return;
        }
    }

    //Collision exit logic
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Catching ground - falling
        if (collision.collider == currentGround)
        {
            currentGround = null;
            falling?.Invoke();
            return;
        }

        //Catching wall - leave the wall
        if (collision.collider == currentWall)
        {
            currentWall = null;
            wallLeft?.Invoke();
            return;
        }
    }
}