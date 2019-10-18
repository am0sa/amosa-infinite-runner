using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisManager : MonoBehaviour
{
    public GameManager gameManager;

    private float duration;
    private Collider2D _collider;

    void Start()
    {
        duration = 7.7f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<Rigidbody2D>().AddTorque(125f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (gameManager.WORLD_LEFT_SPEED) * Time.deltaTime);

        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
