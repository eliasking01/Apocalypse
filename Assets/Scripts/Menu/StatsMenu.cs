using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsMenu : MonoBehaviour
{
    public Text accuracyText;
    public GameObject statsMenu;
    
    void Update()
    {
        // sets the stats menu visible once the player dies
        if (PlayerHealth.dead)
        {
            statsMenu.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            statsMenu.SetActive(false);
        }
        
        // sets the accuracy text
        if (Bullet.hitsThisGame == 0 && Bullet.shotsFired == 0)
        {
            accuracyText.text = "ACCURACY: N/A";
        }
        else
        {
            accuracyText.text = "ACCURACY: " + Shooting.accuracy + "%";
        }
    }

    public void Leave()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(Application.loadedLevel);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }
}
