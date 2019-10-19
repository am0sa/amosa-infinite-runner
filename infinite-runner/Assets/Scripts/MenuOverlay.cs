using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOverlay : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject scoresScreen;

    public bool m_pauseScreenIsActive = true;
    public bool m_scoresScreenIsActive = false;

    public void SwitchToSettingsScreen()
    {
        pauseScreen.SetActive(false);
        scoresScreen.SetActive(true);
        m_pauseScreenIsActive = false;
        m_scoresScreenIsActive = true;
    }

    public void SwitchToPauseScreen()
    {
        pauseScreen.SetActive(true);
        scoresScreen.SetActive(false);
        m_pauseScreenIsActive = true;
        m_scoresScreenIsActive = false;
    }
}
