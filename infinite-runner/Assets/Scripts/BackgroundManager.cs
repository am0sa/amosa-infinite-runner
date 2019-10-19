using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameManager gameManager;
    public float levelDrift;
    private float xPos;
    public float xResetPos; // reset position just before -50 xPos

    void Start()
    {
        levelDrift = gameManager.WORLD_LEFT_SPEED;
        xPos = transform.position.x;
        xResetPos = -50f;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = transform.position.x;

        if (!gameManager.isPaused)
        {
            if (xPos > xResetPos)
            {
                transform.Translate(Vector2.left * (levelDrift) * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(100f, transform.position.y, transform.position.z);
            }
        }
    }
}
