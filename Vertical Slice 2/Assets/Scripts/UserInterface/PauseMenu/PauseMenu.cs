using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }
    /*[SerializeField]
    private GameObject pauseMenu;
    private bool isPaused = false;


    public void ActivatePause()
    {
        if (!isPaused) Pause();
        else Resume();
    }

    // Pause the game
    private void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    // Resume the game
    private void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }*/
}
