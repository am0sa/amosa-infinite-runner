using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public GameManager gameManager;
    public Animator marioAnimator;
    public Rigidbody2D rigidBody;

    public float MARIO_SPEED;
    public float JUMP_FORCE;

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

    // Start is called before the first frame update
    void Start()
    {
        JUMP_FORCE = 245f;
        MARIO_SPEED = 1f;
        
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
        if (!gameManager.isPaused)
        {
            // if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && !grounded)
            // {
            //     AnimBoolReset();
            // }

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

                transform.Translate(Vector2.right * MARIO_SPEED * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") <= 0)
            {
                if (marioAnimator.GetBool("MarioIsRunning"))
                {
                    marioAnimator.SetBool("MarioIsRunning", false);
                }
                if (grounded)
                {
                    marioAnimator.SetBool("MarioStandStill", true);
                }
                
                transform.Translate(Vector2.left * MARIO_SPEED * Time.deltaTime);
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
    
        if (other.gameObject.tag == "mushroom")
        {
            pointsEarned += 100;
        }
    }
}
