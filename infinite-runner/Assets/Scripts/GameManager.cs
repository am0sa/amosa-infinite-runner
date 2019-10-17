using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameObject menuOverlay;

    public bool isPaused = false;

    void Awake() 
    {
        SetInstance();
    }

    void SetInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            menuOverlay.SetActive(true);
        }
    }

    public void UnpauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            menuOverlay.SetActive(false);
        }
    }
    
}
