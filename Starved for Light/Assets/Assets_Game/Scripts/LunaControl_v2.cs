using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class LunaControl_v2 : MonoBehaviour
{
    public float t = 0f;
    public float t2 = 0f;
    public float tJumpSpeed = 0f;
    public float speed = 0f;

    public float sneakSpeed = 0.8f;
    public float trotSpeed = 1.5f;
    public float galopSpeed = 1.5f;
    public float jumpforceReference;

    bool facingRight = true;
    private bool troting = false;
    private bool sneaking = false;
    private bool jumping = false;
    public bool grounded;
    public bool readyToJump = false;
    public bool CanHoldJump = true;
    public float jumpDelay = 1f;

    public float _timeHeld = 0.0f;
    public float _timeForFullJump = 2.0f;
    public float _minJumpForce = 0.5f;
    public float _maxJumpForce = 2.0f;
    public float _leftJumpForce = 1.0f;

    private Rigidbody2D RB2D;
    private BoxCollider2D GroundTrigger;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;

    public float jumpForce = 400f;

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
        if (!sneaking)
        {
            RB2D.velocity = new Vector2(speed * trotSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (sneaking)
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
        //galop animation
        bool galop = InputManager.GetButton("Sprint");
        if (!sneaking)
        {

            if (galop && troting && Mathf.Abs(move) == 1 && facingRight)
            {
                t += (Time.deltaTime);
                RB2D.velocity = new Vector2((speed * trotSpeed) + galopSpeed * (Mathf.Lerp(0f, 2f, t)), gameObject.GetComponent<Rigidbody2D>().velocity.y);
                anim.SetBool("Galop", true);

            }
            else if (galop && troting && Mathf.Abs(move) == 1 && !facingRight)
            {
                t += (Time.deltaTime);
                RB2D.velocity = new Vector2((speed * trotSpeed) - galopSpeed * (Mathf.Lerp(0f, 2f, t)), gameObject.GetComponent<Rigidbody2D>().velocity.y);
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
        //jump
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, groundLayer);

        if (!grounded)
        {
            readyToJump = false;
        }
        if (grounded)
        {
            StartCoroutine("ExecuteAfterTime");
        }
        else
        {
            StopCoroutine("ExecuteAfterTime");
        }

        if (InputManager.GetButtonUp("Jump"))
        {
            tJumpSpeed = 0f;
        }
        if (readyToJump)
        {
            CanHoldJump = true;
        }
        if (grounded)
        {

        }

        if (InputManager.GetButton("Jump") && CanHoldJump)
        {
            Jump();
            tJumpSpeed += (Time.deltaTime * 20);
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
            tJumpSpeed = 0f;
        }
        jumpforceReference = jumpForce * (Mathf.Lerp(_maxJumpForce, 0f, tJumpSpeed));
    }

//groundReady

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(jumpDelay);
        readyToJump = true;



        }
    public void Jump()
    {
         RB2D.AddForce(new Vector2(0, jumpForce * (Mathf.Lerp(_maxJumpForce, 0f, tJumpSpeed))));
    }

    void update()
    {
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}