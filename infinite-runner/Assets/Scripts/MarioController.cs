using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public GameManager gameManager;
    public Animator marioAnimator;
    public Rigidbody2D rigidBody;

    public float DEFAULT_MARIO_SPEED;
    public float marioSpeed;
    public float JUMP_FORCE;
    public float levelDrift;

    public int pointsEarned;

    public bool grounded;

    public void AnimBoolReset()  //Reset mario to Idle Stance
    {
        marioAnimator.SetBool("MarioIsRunning", false);
        marioAnimator.SetBool("MarioIsDucking", false);
        marioAnimator.SetBool("MarioIsAirborne", false);
        marioAnimator.SetBool("MarioJump", false);
        marioAnimator.SetBool("MarioStandStill", false);
    }

    void Start()
    {
        levelDrift = gameManager.WORLD_LEFT_SPEED;
        JUMP_FORCE = 245f;
        DEFAULT_MARIO_SPEED = 6.5f;
        marioSpeed = DEFAULT_MARIO_SPEED;

        rigidBody = GetComponent<Rigidbody2D>();

        marioAnimator.SetBool("MarioIsRunning", false);
        marioAnimator.SetBool("MarioIsDucking", false);
        marioAnimator.SetBool("MarioIsAirborne", false);
        marioAnimator.SetBool("MarioJump", false);
        marioAnimator.SetBool("MarioStandStill", false);

        pointsEarned = 0;
    }

    void Update()
    {
        if (transform.position.y <= 0.484f)
        {
            grounded = true;
        }

        if (!gameManager.isPaused)
        {
            transform.Translate(Vector2.left * (levelDrift) * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                marioSpeed = DEFAULT_MARIO_SPEED * 2.5f;
            }
            else
            {
                marioSpeed = DEFAULT_MARIO_SPEED;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameManager.PauseGame();
            }

            if (!grounded)
            {
                marioAnimator.SetBool("MarioIsAirborne", true);
            }
            else
            {
                marioAnimator.SetBool("MarioIsAirborne", false);
                marioAnimator.SetBool("MarioJump", false);
            }

            //Animator Bools and Movement
            if ((Input.GetAxis("Vertical") < 0 ) && grounded && (Input.GetAxis("Horizontal") == 0 ))
            {
                marioAnimator.SetBool("MarioIsDucking", true);
                marioAnimator.SetBool("MarioIsRunning", false);
            }
            else
            {
                marioAnimator.SetBool("MarioIsDucking", false);
                marioAnimator.SetBool("MarioIsRunning", true);
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                if (marioAnimator.GetBool("MarioStandStill")) 
                { 
                    marioAnimator.SetBool("MarioStandStill", false); 
                }

                if (grounded)
                {
                    marioAnimator.SetBool("MarioIsRunning", true);
                }

                transform.Translate(Vector2.right * marioSpeed * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                if (grounded)
                {
                    marioAnimator.SetBool("MarioIsRunning", true);
                }
                
                transform.Translate(Vector2.left * (marioSpeed) * Time.deltaTime);
            }
            
            if (Input.GetKey(KeyCode.W) && grounded)
            {
                if (!marioAnimator.GetBool("MarioIsAirborne"))
                {
                    marioAnimator.SetBool("MarioJump", true);
                }
                rigidBody.AddRelativeForce(Vector2.up * JUMP_FORCE);
                grounded = false;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rigidBody.gravityScale = 0.5f;
            }
            else
            {
                rigidBody.gravityScale = 1f;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameManager.UnpauseGame();
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer == 8) 
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    
    }
}
