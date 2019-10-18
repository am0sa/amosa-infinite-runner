using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectManager : MonoBehaviour
{
    public GameManager gameManager;
    private float bonusSpeed;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bonusSpeed = Random.Range(0f, 4f);
    }

    void Update()
    {
        transform.Translate(Vector2.left * (gameManager.WORLD_LEFT_SPEED + bonusSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("YOU DIED !!!");
            other.transform.parent.position = new Vector3(0, 1, 0);
        }
    }
}
