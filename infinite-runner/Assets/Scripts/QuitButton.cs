using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("You Can't Quit from the Editor");
        Application.Quit();
    }
}
