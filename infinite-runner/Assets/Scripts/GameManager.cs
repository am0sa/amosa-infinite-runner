using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameObject m_pauseMenu;

    public bool m_isPaused = false;

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
        if (!m_isPaused)
        {
            Time.timeScale = 0;
            m_isPaused = true;
            m_pauseMenu.SetActive(true);
        }
    }

    public void UnpauseGame()
    {
        if (m_isPaused)
        {
            Time.timeScale = 1;
            m_isPaused = false;
            m_pauseMenu.SetActive(false);
        }
    }
    
}
