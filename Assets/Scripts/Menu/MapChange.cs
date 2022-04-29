using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour
{
    public Image mapPreview;

    public Animator animator;
    bool mapsBar = false;
    public Text highScoreText;

    public static string selectedMap = "Default";
    string prevSelectedMap = "Default";

    public void Maps()
    {
        if (!mapsBar)
        {
            animator.SetTrigger("Maps In");
            mapsBar = true;
        }
        else
        {
            animator.SetTrigger("Maps Out");
            mapsBar = false;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    string ToTime(float time)
    {
        string hours = Mathf.FloorToInt((time % 216000) / 3600).ToString("00");
        string minutes = Mathf.FloorToInt((time % 3600) / 60).ToString("00");
        string seconds = Mathf.FloorToInt(time % 60).ToString("00");
        return hours + ":" + minutes + ":" + seconds;
    }

    void SwitchMap() {
        MapJson.instance.ScanMap();

        // changed map preview image
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Documents/Apocalypse Maps/" + selectedMap;
        var mapSprite = IMG2Sprite.instance.LoadNewSprite(path + "/map.png");
        mapPreview.sprite = mapSprite;

        // changes highscore text
        MapJson mapJson = GetComponent<MapJson>();
        var map = mapJson.map;
        highScoreText.text = ToTime(map.highScore);

        // changes the foreground color
        Color color;
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (ColorUtility.TryParseHtmlString(map.foregroundColor, out color))
        {
            camera.backgroundColor = color;
        }
    }

    void Start() {
        SwitchMap();
    }

    void Update() {
        if (selectedMap != prevSelectedMap) {
            prevSelectedMap = selectedMap;
            SwitchMap();
        }
    }
}
