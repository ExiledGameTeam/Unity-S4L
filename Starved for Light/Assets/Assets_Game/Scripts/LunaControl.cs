using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class LunaControl : MonoBehaviour
{
    public float t = 0f;
    public float t2 = 0f;
    public float speed = 0f;

    public float sneakSpeed = 0.8f;
    public float galopspeed = 3f;
    public float maxSpeed = 1.5f;


    bool facingRight = true;
    private bool troting = false;
    private bool sneaking = false;

    private Rigidbody2D RB2D;

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


        t2 += (Time.deltaTime * 2);


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
            speed = move;

        }
        else if (speed < move && !facingRight)
        {
            speed = move;
        }
        if (!sneaking)
        {
            RB2D.velocity = new Vector2(speed * maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
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
        if (!sneaking)
        {
            bool galop = InputManager.GetButton("Sprint");

            if (galop && troting && Mathf.Abs(move) == 1 && facingRight)
            {
                t += (Time.deltaTime);
                RB2D.velocity = new Vector2((speed * maxSpeed) + (Mathf.Lerp(0f, 2f, t)), gameObject.GetComponent<Rigidbody2D>().velocity.y);
                anim.SetBool("Galop", true);

            }
            else if (galop && troting && Mathf.Abs(move) == 1 && !facingRight)
            {
                t += (Time.deltaTime);
                RB2D.velocity = new Vector2((speed * maxSpeed) - (Mathf.Lerp(0f, 2f, t)), gameObject.GetComponent<Rigidbody2D>().velocity.y);
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