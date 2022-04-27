using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Steamworks;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    string ToTime(float time)
    {
        string hours = Mathf.FloorToInt((time % 216000) / 3600).ToString("00");
        string minutes = Mathf.FloorToInt((time % 3600) / 60).ToString("00");
        string seconds = Mathf.FloorToInt(time % 60).ToString("00");
        return hours + ":" + minutes + ":" + seconds;
    }

    void Update()
    {
        MapJson mapJson = GetComponent<MapJson>();
        var map = mapJson.map;
        highScoreText.text = ToTime(map.highScore);
        print(map.highScore);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
