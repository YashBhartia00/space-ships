using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject joystics;
    public GameObject shopMenuUI;
    public GameObject pauseButtonUI;

    public score score;

    void Update()
    {
        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<score>();
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

    public void MainMenu()
    {
        score.scoreNum = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
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
