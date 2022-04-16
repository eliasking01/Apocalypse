using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Steamworks;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    string ToTime(int time)
    {
        string hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        return hours + ":" + minutes + ":" + seconds;
    }

    void Update()
    {
        if (PlayerStats.steamStats && SteamManager.Initialized)
        {
            SteamUserStats.GetStat("highScoreMap1", out int hs1);
            SteamUserStats.GetStat("highScoreMap2", out int hs2);
            SteamUserStats.GetStat("highScoreMap3", out int hs3);

            if (MapChange.map1Selected)
            {
                highScoreText.text = ToTime(hs1);
            }
            else if (MapChange.map2Selected)
            {
                highScoreText.text = ToTime(hs2);
            }
            else if (MapChange.map3Selected)
            {
                highScoreText.text = ToTime(hs3);
            }
        }
        
        // offline
        else
        {
            if (MapChange.map1Selected)
            {
                highScoreText.text = PlayerPrefs.GetString("HighScoreMap1", "00:00:00");
            }
            else if (MapChange.map2Selected)
            {
                highScoreText.text = PlayerPrefs.GetString("HighScoreMap2", "00:00:00");
            }
            else if (MapChange.map3Selected)
            {
                highScoreText.text = PlayerPrefs.GetString("HighScoreMap3", "00:00:00");
            }
        }
    }

    public void PlayGame()
    {
        if (MapChange.map1Selected)
        {
            SceneManager.LoadScene(1);
        }
        else if (MapChange.map2Selected)
        {
            SceneManager.LoadScene(2);
        }
        else if (MapChange.map3Selected)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
