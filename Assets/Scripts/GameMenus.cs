using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenus : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool gameIsPaused = false;
    public GameObject loseMenu;

    void Update()
    {
        PauseMenu();
    }

    public void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && loseMenu.activeInHierarchy == false)
        {
            if(gameIsPaused == false)
            {
                pauseMenu.SetActive(true);
                gameIsPaused = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else if(gameIsPaused == true)
            {
                pauseMenu.SetActive(false);
                gameIsPaused = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void MainMenuButton()
    {
        pauseMenu.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
