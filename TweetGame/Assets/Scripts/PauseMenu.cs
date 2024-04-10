using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool GamePaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void Paused()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("ByeBye");
        Application.Quit();
    }
}
