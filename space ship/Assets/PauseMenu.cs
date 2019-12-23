using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject joystics;
    void Update()
    {
        if (Input.touchCount >4){
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

     public void Resume()
    {
        pauseMenuUI.SetActive(false);
        joystics.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        joystics.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        print("L");
    }
    public void pauseButton()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
