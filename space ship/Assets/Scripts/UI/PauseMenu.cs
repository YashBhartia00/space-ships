using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject joystics;
    public GameObject shopMenuUI;
    public GameObject pauseButtonUI;

    void Update()
    {
       /* if (Input.touchCount >4){
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        joystics.SetActive(true);
        pauseButtonUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        joystics.SetActive(false);
        pauseButtonUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void shopMenu()
    {
        if (!shopMenuUI.activeSelf)
        {
            shopMenuUI.SetActive(true);
            pauseMenuUI.SetActive(false);
        } else
        {
            shopMenuUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        }
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
