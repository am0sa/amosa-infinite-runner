using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarioController : MonoBehaviour
{
    public GameManager gameManager;
    public Animator marioAnimator;
    public Rigidbody2D rigidBody;

    public float DEFAULT_MARIO_SPEED;
    public float marioSpeed;
    public float JUMP_FORCE;
    public float levelDrift;
    public float longestLife;
    public float currentLife;

    public int pointsEarned;
    public int highestScore;

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
        if (!gameManager.isPaused)
        {
            currentLife += Time.deltaTime;
            
            if (pointsEarned >= highestScore)
            {
                highestScore = pointsEarned;
            }

            if (currentLife >= longestLife)
            {
                longestLife = currentLife;
            }

            gameManager.highestScore.text = "Hishest Score: " + highestScore.ToString();
            gameManager.currentScore.text = "Current Score: " + pointsEarned.ToString();
            gameManager.longestLife.text = "Longest Life: " + ((int)longestLife).ToString();
            gameManager.currentLife.text = "Current Life: " + ((int)currentLife).ToString();
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

        if (other.gameObject.layer == 10)
        {
            Debug.Log("You Died !!!");
            transform.position = new Vector3(0, 1, 0);
            pointsEarned = 0;
            currentLife = 0;
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "coin1")
        {
            pointsEarned += 1;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (other.tag == "coin2")
        {
            pointsEarned += 2;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (other.tag == "pointsLarge")
        {
            pointsEarned += 10;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (other.tag == "pointsSmall")
        {
            pointsEarned += 5;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (other.gameObject.layer == 10)
        {
            Debug.Log("You Died !!!");
            transform.position = new Vector3(0, 1, 0);
            pointsEarned = 0;
            currentLife = 0;
        }
    }
}
