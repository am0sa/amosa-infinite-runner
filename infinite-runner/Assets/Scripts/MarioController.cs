using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public GameManager gameManager;
    public float MARIO_SPEED;
    public float JUMP_FORCE;
    public float HOVER_FORCE;

    public Animator marioAnimator;



    // Start is called before the first frame update
    void Start()
    {
        marioAnimator.SetBool("MarioIsRunning", false);
        marioAnimator.SetBool("MarioIsDucking", false);
        marioAnimator.SetBool("MarioIsAirborne", false);
        marioAnimator.SetBool("MarioJump", false);
        marioAnimator.SetBool("MarioStandStill", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            marioAnimator.SetBool("MarioIsRunning", true);
        }
        else
        {
            marioAnimator.SetBool("MarioIsRunning", false);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            marioAnimator.SetBool("MarioJump", true);
        }

        if (Input.GetAxis("Horizontal") <= 0)
        {
            marioAnimator.SetBool("MarioIsRunning", false);
            marioAnimator.SetBool("MarioStandStill", true);
        }
        

        if (!gameManager.isPaused)
        {

        }

    }
}
