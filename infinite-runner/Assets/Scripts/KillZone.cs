using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("YOU DIED !!!");
            other.transform.parent.position = new Vector3(0, 1, 0);
        }
        else
        {
            Destroy(other.gameObject);
        }
        
    }
}
