using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameisPaused)
            {
                Debug.Log("Resume");
                Resume();
            }else if (!GameisPaused)
            {
                Pause();
            }




        }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void quit()
    {
        Application.Quit();
    }
}
