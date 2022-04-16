using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool buyMenuOpen = false;

    public GameObject pauseMenuUI;

    public GameObject buyMenuUI;

    void Start()
    {
        buyMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlayerHealth.dead)
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

        if (Input.GetKey(KeyCode.Tab) && !GameIsPaused && !PlayerHealth.dead)
        {
            buyMenuUI.SetActive(true);
            Cursor.visible = true;
            buyMenuOpen = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            buyMenuUI.SetActive(false);
            Cursor.visible = false;
            buyMenuOpen = false;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Cursor.visible = false;

        if (!PlayerHealth.dead)
        {
            Time.timeScale = 1f;
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        buyMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
