using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class LunaControl_v2 : MonoBehaviour
{
    public float t = 0f;
    public float t2 = 0f;
    public float tJumpSpeed = 0f;
    public float tDoubleJumpSpeed = 0f;
    public float tHoverSpeed = 0f;
    public float speed = 0f;

    public float sneakSpeed = 0.8f;
    public float trotSpeed = 1.5f;
    public float galopSpeed = 1.5f;
    public float GalopAccelerate = 0f;
    public float jumpforceReference;

    bool facingRight = true;
    private bool troting = false;
    private bool sneaking = false;
    private bool jumping = false;
    public bool grounded;
    public bool readyToJump = false;
    public bool CanHoldJump = true;
    public float jumpDelay = 1f;
    public bool canDoubleJump = false;
    public bool DoubleJumped = false;
    public bool JustDoubleJumped = false;
    public bool LongJump = false;
    public bool JustJumped = false;

    public float _timeHeld = 0.0f;
    public float timeForFullJump = 10f;
    public float timeForFullDoubleJump = 0f;
    public float _maxJumpForce = 2.0f;
    public float _leftJumpForce = 1.0f;

    private Rigidbody2D RB2D;
    private BoxCollider2D GroundTrigger;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;

    public float jumpForce = 46f;
    public float jumpForceBase = 0f;
    public float LongjumpForceBase = 0f;
    public float LongJumpForwardForce = 0f;
    public float DoubleJumpForce = 0f;
    public float DoubleJumpForceBase = 0f;
    public float FlySpeed = 0f;

    public float HoverForce = 0f;

    Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("FacingRight", true);
        anim.SetBool("Troting", false);
        anim.SetBool("Galop", false);
        anim.SetBool("Sneaking", false);

        RB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Trot animation
        float move = InputManager.GetAxis("Horizontal");
        anim.SetFloat("MoveInput", Mathf.Abs(move));
        //Sneak check {
        if (InputManager.GetButton("Sneak"))
        {
            sneaking = true;
            anim.SetBool("Sneaking", true);
        }
        if (!InputManager.GetButton("Sneak"))
        {
            sneaking = false;
            anim.SetBool("Sneaking", false);
        }
        //}


        if (facingRight)
        {
            speed = (Mathf.Lerp(0f, 1f, t2));
        }
        else if (!facingRight)
        {
            speed = (Mathf.Lerp(0f, -1f, t2));
        }


        t2 += (Time.deltaTime * 3);


        if (!facingRight && move < 0.15 && move >= 0)
        {
            t2 = 0;
        }

        else if (facingRight && move > -0.15 & move <= 0)
        {
            t2 = 0;
        }

        if (speed > move && facingRight)
        {
            speed = (Mathf.Lerp(speed, move, 0.1f));
            t2 = speed;

        }
        else if (speed < move && !facingRight)
        {
            speed = (Mathf.Lerp(speed, move, 0.1f));
            t2 = Mathf.Abs(speed);
        }
        if (!sneaking && grounded)
        {
            RB2D.velocity = new Vector2(speed * trotSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (sneaking && grounded)
        {
            RB2D.velocity = new Vector2(speed * sneakSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (move > 0 && !facingRight)
        {
            Flip();
            anim.SetBool("FacingRight", true);
        }

        else if (move < 0 && facingRight)
        {
            Flip();
            anim.SetBool("FacingRight", false);
        }
        if (InputManager.GetAxisRaw("Horizontal") != 0)
        {
            if (troting == false)
            {
                anim.SetBool("Troting", true);
                troting = true;
            }
        }
        if (move < 0.1 && move > -0.1)
        {
            troting = false;
            anim.SetBool("Troting", false);
        }
//###############################################
//#                   GALOP                     #
//###############################################
        bool galop = InputManager.GetButton("Sprint");
        if (!sneaking && grounded)
        {

            if (galop && troting && Mathf.Abs(move) == 1 && facingRight)
            {
                t += (Time.deltaTime * GalopAccelerate);
                RB2D.AddForce(new Vector2((speed * trotSpeed) + galopSpeed * (Mathf.Lerp(0f, 2f, t)), gameObject.GetComponent<Rigidbody2D>().velocity.y));
                anim.SetBool("Galop", true);

            }
            else if (galop && troting && Mathf.Abs(move) == 1 && !facingRight)
            {
                t += (Time.deltaTime * GalopAccelerate);
                RB2D.AddForce(new Vector2((speed * trotSpeed) - galopSpeed * (Mathf.Lerp(0f, 2f, t)), gameObject.GetComponent<Rigidbody2D>().velocity.y));
                anim.SetBool("Galop", true);
            }
            else
            {
                t = 0f;
                anim.SetBool("Galop", false);
            }
        }
        if (sneaking)
        {
            t = 0;
        }
//##############################################
//#                     JUMP                   #
//##############################################
    }

    void Update()
    {
        if (t > 1)
        {
            LongJump = true;
        }
        if (t < 1)
        {
            LongJump = false;
        }
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, groundLayer);
        if (!LongJump)
        {
            if (grounded && !InputManager.GetButton("Jump"))
            {
                StartCoroutine("ExecuteAfterTime");
            }
            else if (InputManager.GetButtonDown("Jump"))
            {
                StopCoroutine("ExecuteAfterTime");
            }
            if (InputManager.GetButtonUp("Jump"))
            {
                tJumpSpeed = 0f;
            }
            if (readyToJump && !InputManager.GetButton("Jump"))
            {
                CanHoldJump = true;
            }
            if (jumpforceReference == 0 || InputManager.GetButtonUp("Jump"))
            {
                CanHoldJump = false;
            }
            if (!CanHoldJump)
            {
                JustJumped = false;
            }
            if (InputManager.GetButtonDown("Jump") && grounded)
            {
                JustJumped = true;
                RB2D.AddForce(new Vector2(0, jumpForceBase));
            }
            if (!grounded)
            {
                readyToJump = false;
            }
            if (InputManager.GetButton("Jump") && CanHoldJump)
            {
                Jump();
                tJumpSpeed += (Time.fixedDeltaTime * timeForFullJump);
            }

            if (grounded)
            {
                canDoubleJump = false;
                DoubleJumped = false;
            }
            if (!grounded && canDoubleJump && InputManager.GetButtonUp("Jump"))
            {
                DoubleJumped = true;
            }
            if (!grounded)
            {
                if (!InputManager.GetButton("Jump"))
                {
                    canDoubleJump = true;
                }
            }
            if (!DoubleJumped && !grounded && canDoubleJump && InputManager.GetButtonDown("Jump"))
            {
                RB2D.velocity = new Vector2(RB2D.velocity.x, 0);
                RB2D.AddForce(new Vector2(0, DoubleJumpForceBase));
            }
            if (!DoubleJumped && !grounded && canDoubleJump && InputManager.GetButton("Jump"))
            {
                DoubleJump();
                tDoubleJumpSpeed += (Time.deltaTime * timeForFullDoubleJump);
            }
        }
        if (LongJump)
        {
            if (grounded && !InputManager.GetButton("Jump"))
            {
                StartCoroutine("ExecuteAfterTime");
            }
            else if (InputManager.GetButtonDown("Jump"))
            {
                StopCoroutine("ExecuteAfterTime");
            }
            if (InputManager.GetButtonUp("Jump"))
            {
                tJumpSpeed = 0f;
            }
            if (readyToJump && !InputManager.GetButton("Jump"))
            {
                CanHoldJump = true;
            }
            if (jumpforceReference == 0 || InputManager.GetButtonUp("Jump"))
            {
                CanHoldJump = false;
            }
            if (!CanHoldJump)
            {
                JustJumped = false;
            }
            if (InputManager.GetButtonDown("Jump") && grounded)
            {
                JustJumped = true;
                RB2D.AddForce(new Vector2(0, LongjumpForceBase));
                if (!grounded)
                {
                    readyToJump = false;
                }
            }
            if (InputManager.GetButton("Jump") && CanHoldJump)
            {
                Jump();
                tJumpSpeed += (Time.fixedDeltaTime * timeForFullJump);
            }

            if (grounded)
            {
                canDoubleJump = false;
                DoubleJumped = false;
                JustDoubleJumped = false;
            }

            if (!grounded && canDoubleJump && InputManager.GetButtonUp("Jump"))
            {
                DoubleJumped = true;
            }
            if (!grounded && canDoubleJump && InputManager.GetButtonDown("Jump"))
            {
                JustDoubleJumped = true;
            }
            if (!grounded)
            {
                if (!InputManager.GetButton("Jump"))
                {
                    canDoubleJump = true;
                }
            }
            if (!DoubleJumped && !grounded && canDoubleJump && InputManager.GetButtonDown("Jump"))
            {
                RB2D.velocity = new Vector2(RB2D.velocity.x, 0);
                RB2D.AddForce(new Vector2(0, DoubleJumpForceBase));
            }
            if (!DoubleJumped && !grounded && canDoubleJump && InputManager.GetButton("Jump"))
            {
                DoubleJump();
                tDoubleJumpSpeed += (Time.deltaTime * timeForFullDoubleJump);
            }
        }


            if (InputManager.GetButton("Jump"))
        {
            jumping = true;
        }
        if (!InputManager.GetButton("Jump"))
        {
            jumping = false;
        }
        if (grounded || !jumping)
        {
            tDoubleJumpSpeed = 0f;
            tJumpSpeed = 0f;
        }
        jumpforceReference = jumpForce * (Mathf.Lerp(_maxJumpForce, 0f, tJumpSpeed));
        if ((!grounded && !LongJump) || JustDoubleJumped)
        {
            RB2D.velocity = new Vector2(speed * trotSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (!readyToJump && !JustJumped)
        {
            CanHoldJump = false;
        }
//Hover
        if (!grounded)
        {
            if(InputManager.GetAxisRaw("Hover") == 1 || InputManager.GetButton("Hover"))
            {
                Debug.Log("Derp");
                RB2D.velocity = new Vector2(RB2D.velocity.x, (Mathf.Lerp(RB2D.velocity.y, HoverForce, tHoverSpeed)));
                tHoverSpeed += (Time.deltaTime);
            }
        }
        else
        {
            tHoverSpeed = 0f;
        }
    }
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(jumpDelay);
        readyToJump = true;
    }
    public void Jump()
    {
        if (LongJump)
        {
            RB2D.AddForce(new Vector2(0, jumpForce / 4 * (Mathf.Lerp(_maxJumpForce, 0f, tJumpSpeed))));
        }
        if (!LongJump)
        {
            RB2D.AddForce(new Vector2(0, jumpForce * (Mathf.Lerp(_maxJumpForce, 0f, tJumpSpeed))));
        }

    }
    public void DoubleJump()
    {
        if (LongJump)
        {
            RB2D.AddForce(new Vector2(0, DoubleJumpForce * (Mathf.Lerp(_maxJumpForce, 0f, tDoubleJumpSpeed))));
        }
        if (!LongJump)
        {
            RB2D.AddForce(new Vector2(0, DoubleJumpForce * (Mathf.Lerp(_maxJumpForce, 0f, tDoubleJumpSpeed))));
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}