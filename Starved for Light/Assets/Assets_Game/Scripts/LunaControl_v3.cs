using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class LunaControl_v3 : MonoBehaviour {

    [SerializeField] private float m_MaxWalkSpeed;
    [SerializeField] private float m_MaxSprintSpeed;
    [SerializeField] private float m_MaxSneakSpeed;
    [SerializeField] private float m_Acceleration;
    [SerializeField] private float m_BrakeFactor;

    [SerializeField] private float m_FloatFallSpeed;

    [SerializeField] private float m_JumpForce;
    [SerializeField] private float m_JumpSustainForce;
    [SerializeField] private float m_JumpSustainDuration;

    [SerializeField] private float m_LongJumpWindow;
    [SerializeField] private float m_LongJumpForce;
    [SerializeField] private float m_LongJumpForwardForce;
    [SerializeField] private float m_LongJumpMaxSpeed;

    [SerializeField] private float m_WallJumpForce;
    [SerializeField] private float m_WallJumpForwardForce;
    [SerializeField] private float m_WallJumpInputDampeningDuration;
    [SerializeField] private float m_WallSlowDown;
    [SerializeField] private float m_ClimbSpeed;

    [SerializeField] private float m_InputDeadZone;

    private float m_MaxSpeed;
    private float m_ActualMaxSpeed;

    [SerializeField] private float m_InputDampeningFactor; //to reduce input when needed, should only ever be between 0 and 1
    private float m_InputDampeningStart;
    private float m_InputDampeningDuration = 1f;

    private float m_JumpSustainStart;
    private float m_TimeLastSprinted;

    private float m_Input;
    [SerializeField] private float m_RawInput;
    [SerializeField] private float m_RawVertInput;

    [SerializeField] private bool m_FacingRight;
    private bool m_Grounded;
    private bool m_JumpableWalled;
    private bool m_ClimbableWalled;
    private bool m_WalledLastFrame;
    [SerializeField] private bool m_Sneaking;
    [SerializeField] private bool m_Sprinting;

    private bool m_CanDoubleJump;
    private bool m_SustainingJump;
    [SerializeField] private bool m_LongJumping;

    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_WallCheck;
    [SerializeField] private Transform m_HighWallCheck;
    [SerializeField] private LayerMask m_Ground;
    [SerializeField] private LayerMask m_JumpableWalls;
    [SerializeField] private LayerMask m_ClimbableWalls;

    private bool Walled
    {
        get { return m_ClimbableWalled || m_JumpableWalled; }
    }

    private Rigidbody2D m_RB2D;

    // Use this for initialization
    void Start () {
        m_RB2D = GetComponent<Rigidbody2D>();
	}


    private void FixedUpdate()
    {

        //read input, reduce by any input dampening
        m_RawInput = Input.GetAxisRaw("Horizontal");
        m_Input = m_RawInput * m_InputDampeningFactor;



        m_Sneaking = false;
        m_Sprinting = false;
        if (m_Grounded && Input.GetButton("Sneak"))
        {
            m_MaxSpeed = m_MaxSneakSpeed;
            m_Sneaking = true;
        }
        else if (Input.GetAxisRaw("RightTrigger") > 0.5f)
        {
            m_MaxSpeed = m_MaxSprintSpeed;
            m_TimeLastSprinted = Time.time;
            m_Sprinting = true;
        }
        else
        {
            m_MaxSpeed = m_MaxWalkSpeed;
        }

        if (m_LongJumping)
        {
            m_MaxSpeed = m_LongJumpMaxSpeed;
        }

        //only process player input if they are not long jumping
        if (!m_LongJumping)
        {

            //if the input is greater than our dead zone
            if (Mathf.Abs(m_RawInput) > m_InputDeadZone)
            {
                //add acceleration
                m_RB2D.AddForce(new Vector2(m_Input * m_Acceleration * m_InputDampeningFactor, 0f));
            }
            else
            {
                //reduce the speed of the character
                m_RB2D.AddForce(new Vector2(m_RB2D.velocity.x * -m_BrakeFactor * Mathf.Pow(m_InputDampeningFactor, 2f), 0f));
            }


            if (m_ClimbableWalled)
            {
                //get vertical input
                m_RawVertInput = Input.GetAxisRaw("Vertical");
                //if it exceeds the dead zone
                if(Mathf.Abs(m_RawVertInput) > m_InputDeadZone)
                    m_RB2D.velocity = new Vector2(m_RB2D.velocity.x, m_RawVertInput * m_ClimbSpeed);
                else
                {
                    m_RB2D.velocity = new Vector2(m_RB2D.velocity.x, 0f);
                }
            }

            

            //managed the sustained jump
            if (m_SustainingJump)
            {
                //if the duration is over, or the button has been released
                if (Time.time > m_JumpSustainStart + m_JumpSustainDuration || !Input.GetButton("Jump"))
                {
                    //stop sustaining
                    m_SustainingJump = false;
                }
                else
                {
                    //add sustain force
                    m_RB2D.AddForce(Vector2.up * m_JumpSustainForce);
                }
            }            
        }
        else //long jumping
        {
            if(m_FacingRight && m_Input < -m_InputDeadZone)
            {
                m_LongJumping = false;
            }
            if (!m_FacingRight && m_Input > m_InputDeadZone)
            {
                m_LongJumping = false;
            }
        }

        //if the jump button is held, and the char is falling faster than the float fall speed
        if (Input.GetButton("Jump") && m_RB2D.velocity.y < -m_FloatFallSpeed)
        {
            //set the vertical velocity to the float fall speed
            m_RB2D.velocity = new Vector2(m_RB2D.velocity.x, -m_FloatFallSpeed);
        }

        //slightly increase max speed is input is being dampened
        m_ActualMaxSpeed = Mathf.Lerp(m_LongJumpMaxSpeed, m_MaxSpeed, m_InputDampeningFactor);

        //limit horizontal velocity
        if (m_RB2D.velocity.x > m_ActualMaxSpeed)
        {
            m_RB2D.velocity = new Vector2(m_ActualMaxSpeed, m_RB2D.velocity.y);
        }
        if (m_RB2D.velocity.x < -m_ActualMaxSpeed)
        {
            m_RB2D.velocity = new Vector2(-m_ActualMaxSpeed, m_RB2D.velocity.y);
        }


        TryFlip();
    }

    
    void Update () {

        //calculate any input dampening required
        m_InputDampeningFactor = Mathf.InverseLerp(0f, m_InputDampeningDuration, Time.time - m_InputDampeningStart);

        //check if char is grounded
        m_Grounded = Physics2D.OverlapCircle(m_GroundCheck.position, 0.1f, m_Ground);

        //check if char is on a climbable surface
        m_ClimbableWalled = Physics2D.OverlapCircle(m_WallCheck.position, 0.1f, m_ClimbableWalls);

        //if not, check if they're on a jumpable surface
        if(!m_ClimbableWalled)
            m_JumpableWalled = Physics2D.OverlapCircle(m_WallCheck.position, 0.1f, m_JumpableWalls);

        if (Walled)
        {
            //m_CanDoubleJump = true;
        }

        //trigger enter or exit wall states
        if (m_WalledLastFrame && !Walled)
        {
            OnLeaveWall();
        }

        if(m_ClimbableWalled && !m_WalledLastFrame)
        {
            OnEnterClimbableWall();
        }

        if (m_JumpableWalled && !m_WalledLastFrame)
        {
            OnEnterJumpableWall();
        }

        SetGravityScale();

        //store the walled state for use next frame
        m_WalledLastFrame = Walled;

        //if char is grounded, reset the can double jump flag
        if (m_Grounded)
            m_CanDoubleJump = true;


        if (Walled)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if ((Physics2D.OverlapCircle(m_HighWallCheck.position, 0.1f, m_ClimbableWalls) || Physics2D.OverlapCircle(m_HighWallCheck.position, 0.1f, m_JumpableWalls)))
                    WallJump();
                else
                    Jump(true);
            }
        }
        else if (m_Grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (m_Sneaking && Time.time < m_TimeLastSprinted + m_LongJumpWindow)
                    LongJump();
                else
                    Jump(false);
            }
        }
        else
        {
            if (m_CanDoubleJump && Input.GetButtonDown("Jump"))
            {
                Jump(true);
                m_CanDoubleJump = false;
            }
        }
	}





    private void Jump(bool isDoubleJump)
    {
        //remove any vertical velocity
        m_RB2D.velocity = new Vector2(m_RB2D.velocity.x, 0f);
        //add force upwards
        m_RB2D.AddForce(Vector2.up * m_JumpForce);
        if (!isDoubleJump)
        {
            //save the time the jump started
            m_JumpSustainStart = Time.time;
            m_SustainingJump = true;
        }
    }

    private void LongJump()
    {
        //remove any vertical velocity
        m_RB2D.velocity = new Vector2(m_RB2D.velocity.x, 0f);

        m_LongJumping = true;

        if(m_FacingRight)
            //add force upwards and forwards
            m_RB2D.AddForce(new Vector2(m_LongJumpForwardForce, m_LongJumpForce));
        else
            m_RB2D.AddForce(new Vector2(-m_LongJumpForwardForce, m_LongJumpForce));
    }



    private void WallJump()
    {
        //remove any vertical velocity
        m_RB2D.velocity = Vector2.zero; //new Vector2(m_RB2D.velocity.x, 0f);

        if (m_FacingRight)
            //add force upwards and forwards
            m_RB2D.AddForce(new Vector2(-m_WallJumpForwardForce, m_WallJumpForce));
        else
            m_RB2D.AddForce(new Vector2(m_WallJumpForwardForce, m_WallJumpForce));

        m_InputDampeningStart = Time.time;
        m_InputDampeningDuration = m_WallJumpInputDampeningDuration;
    }




    void OnLeaveWall()
    {
        m_RB2D.gravityScale = 1f;
    }

    void OnEnterJumpableWall()
    {
        if(m_RB2D.velocity.y < 0f)
            m_RB2D.velocity = new Vector2(m_RB2D.velocity.x, m_RB2D.velocity.y * m_WallSlowDown);
    }

    void OnEnterClimbableWall()
    {
        m_RB2D.velocity = new Vector2(m_RB2D.velocity.x, 0f);
    }

    void SetGravityScale()
    {
        if (m_ClimbableWalled)
        {
            m_RB2D.gravityScale = 0f;
        }
        else if(m_JumpableWalled && m_RB2D.velocity.y < 0f)
        {
            m_RB2D.gravityScale = m_WallSlowDown;
        }
        else
            m_RB2D.gravityScale = 1f;
    }



    //flips the the horizontal axis if conditions are met
    private void TryFlip()
    {
        if(m_RB2D.velocity.x > m_InputDeadZone && !m_FacingRight)
            Flip();
        if (m_RB2D.velocity.x < -m_InputDeadZone && m_FacingRight)
            Flip();
    }


    private void Flip() {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            m_LongJumping = false;
        }
    }
}
