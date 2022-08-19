using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

//Player physics and movement controller
public class PlayerMovement : MonoBehaviour
{
    //Rigidbody reference
    private Rigidbody2D rb, localSpace;

    //Last contacted surfaces references
    private Collider2D currentWall, currentGround;

    //Actions for movement events
    public Action falling, wallLeft, wallTouch, turn, turnComplete;
    public Action<bool> landed;

    //Moving to the right
    private bool _posX;
    public bool FacingPosX { get { return _posX; } set { _posX = value; } }

    //Moving at all
    public bool Moving { get { return (localSpace == null ? rb.velocity != Vector2.zero : Vector2.Equals(localSpace.velocity, rb.velocity)); } }

    //Stats and counters
    private int MaxJumps;
    private int jumpsLeft;
    private float currentJumpForce = -1;

    [SerializeField] float maxSpeed = 8;
    [SerializeField] float maxAirSpeed = 8;
    [SerializeField] float acceleration = 24;
    [SerializeField] float airAcceleration = 24;
    [SerializeField] float minJumpForce = 4.5f;
    [SerializeField] float maxJumpForce = 12.5f;
    [SerializeField] float gravityScale = 3;
    [SerializeField] float wallSlideSpeed = 0.3f;
    [SerializeField] float wallJumpForce = 10f;
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
        _posX = true;

        MoveX = pia.World.Horizontal;

    }

    public void LoadStats(PlayerStatsData data)
    {
        maxSpeed = data.maxSpeed;
        maxAirSpeed = data.maxAirSpeed;
        acceleration = data.acceleration;
        airAcceleration = data.airAcceleration;
        minJumpForce = data.minJumpForce;
        maxJumpForce = data.maxJumpForce;
        wallJumpForce = data.wallJumpForce;
        wallSlideSpeed = data.wallSlideSpeed;
        gravityScale = data.gravityScale;
        rb.gravityScale = gravityScale;
    }
    //Per frame reduction of speed
    public void Decelerate()
    {
        if (localSpace != null)
        {
        }
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;

        if (xCom == 0/*(localSpace == null ? 0 : localSpace.velocity.x)*/)
        {
            //early exit at 0 horizontal speed
            return;
        }

        //Apply deceleration and cap at 0
        xCom -= (xCom > 0 ? 1.75f : -1.75f) * acceleration * Time.fixedDeltaTime;
        xCom = _posX ? Mathf.Max(xCom, 0) : Mathf.Min(xCom, 0);

        //gravity applied here
        yCom -= gravityScale * Time.fixedDeltaTime;

        //Update velocity 
        rb.velocity = new(xCom, yCom);
        ApplyLocalSpaceVelocity();

    }

    //Per frame velocity calculations for the ground
    public void SolveGroundedVelocity()
    {
        //Cache velocity components
        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;

        //apply horizontal acceleration
        xCom += MoveX.ReadValue<float>() * acceleration * Time.fixedDeltaTime;
        xCom = (_posX ? Mathf.Min(xCom, maxSpeed) : Mathf.Max(xCom, -maxSpeed));

        //gravity applied here
        yCom -= gravityScale * Time.fixedDeltaTime;

        //Catch turn attempt logic
        if (rb.velocity.x != 0)
        {
            if (_posX ^ xCom > 0)
            {
                turn?.Invoke();
                return;
            }
        }

        //Update intended direction - this can be moved to somewhere better, doesn't need to run per frame
        _posX = MoveX.ReadValue<float>() != 0 ? (MoveX.ReadValue<float>() > 0) : _posX;

        //Update velocity
        rb.velocity = new(xCom, yCom);
        ApplyLocalSpaceVelocity();

    }

    //Per frame velocity calculations for in air
    //Same as on the ground but:
    // - no turn catch
    // - added application of gravity
    public void SolveAerialVelocity()
    {

        float xCom = rb.velocity.x;
        float yCom = rb.velocity.y;

        //bool rising = yCom > 0;

        xCom += MoveX.ReadValue<float>() * airAcceleration * Time.fixedDeltaTime;
        if (Mathf.Abs(xCom) > maxAirSpeed)
        {
            xCom = (_posX ? Mathf.Min(xCom, maxAirSpeed) : Mathf.Max(xCom, -maxAirSpeed));
        }

        //gravity applied here
        yCom -= gravityScale * Time.fixedDeltaTime;

        rb.velocity = new(xCom, yCom);

        //Fall catch logic
        if (yCom <= 0)
        {
            falling?.Invoke();
        }
    }

    //Toggle intended direction
    public void Turn()
    {
        _posX = !_posX;
    }

    //Set intended direction
    public void TurnToPosX(bool posX)
    {
        _posX = posX;
    }

    //Per frame deceleration for change in direction
    public void ApplyTurn()
    {

        if (Mathf.Abs(rb.velocity.x) < maxSpeed * 0.2f)
        {
            rb.velocity = 0.5f * maxSpeed * (_posX ? Vector2.right : Vector2.left);
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
        if (MoveX.ReadValue<float>() == 0)
        {
            return;
        }
        rb.velocity = (maxSpeed * MoveX.ReadValue<float>() * Vector2.right) + Vector2.down;
    }

    //Halts rigidbody
    public void RestRB()
    {
        rb.velocity = Vector2.zero;
    }

    //Adds vertical velocity for a jump
    public void AddJump()
    {
        if (jumpsLeft <= 0)
        { return; }
        LeaveLocalSpace();
        jumpsLeft--;
        if (currentJumpForce < 0)
        {
            rb.velocity += Vector2.up * maxJumpForce;
            return;
        }
        rb.velocity += Vector2.up * currentJumpForce;
        currentJumpForce = -1;
    }


    public void CacheJump(float charge, float max)
    {
        if (charge != 0)
        {
            float ratio = charge / max;
            currentJumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, ratio);
        }
    }

    //Collision logic
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Catching horizontal surface - landing
        if (Vector2.Dot(collision.GetContact(collision.contactCount - 1).normal, Vector2.up) > 0.85f)
        {
            currentGround = collision.collider;
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

        Debug.Log("WEE");
    }

    //Collision exit logic
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (currentGround != null)
        {
            if (!rb.IsTouching(currentGround))
            {
                currentGround = null;
                if (rb.velocity.y <= 0)
                {
                    falling?.Invoke();
                }
            }
        }

        if (currentWall != null)
        {
            if (!rb.IsTouching(currentWall))
            {
                currentWall = null;
                wallLeft?.Invoke();
            }
        }
        if (collision.rigidbody == null)
        {
            return;
        }
        if (collision.rigidbody == localSpace)
        {
            LeaveLocalSpace();
        }
    }

    public void SetLocalSpace(Rigidbody2D body)
    {
        localSpace = body;
    }

    public void LeaveLocalSpace()
    {
        localSpace = null;
    }

    public void ApplyLocalSpaceVelocity()
    {
        if (localSpace == null)
        {
            return;
        }

        //rb.velocity += localSpace.velocity.x * Vector2.right;
    }

    public void WallSlide()
    {
        Debug.Log(wallSlideSpeed);
        rb.velocity = Vector2.down * wallSlideSpeed;
        _posX = currentWall.ClosestPoint(rb.position).x - rb.position.x < 0;
    }

    public void WallJump()
    {
        rb.velocity = new Vector2(currentWall.ClosestPoint(rb.position).x - rb.position.x < 0 ? 1 : -1, 1.5f) * wallJumpForce;
    }

    public void ToggleGravity()
    {
        rb.gravityScale = rb.gravityScale == 0 ? gravityScale : 0;
    }

    public void WallDrop()
    {
        rb.velocity = 0.4f * wallJumpForce * new Vector2(currentWall.ClosestPoint(rb.position).x - rb.position.x < 0 ? 1 : -1, 0);
    }

    public void Teleport(Vector2 newPos)
    {

        StartCoroutine(IEN_Teleport(newPos));
    }

    private IEnumerator IEN_Teleport(Vector2 newPos)
    {

        rb.isKinematic = true;
        RestRB();
        rb.position = newPos;
        yield return null;
        rb.isKinematic = false;

    }

    public Vector2 FindRelativeToMe(Vector2 offset) {

        return rb.position + offset;

    }

    public void Respawn()
    {
        rb.velocity = Vector2.zero;
        currentGround = null;
        currentWall = null;
        currentJumpForce = -1;
        jumpsLeft = 0;
    }
}