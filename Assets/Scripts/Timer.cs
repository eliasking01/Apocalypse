using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class Timer : MonoBehaviour
{
    public static float theTime;

    MapJson mapJson;

    void Start()
    {
        theTime = 0;

        mapJson = GameObject.Find("GameObject").GetComponent<MapJson>();
    }

    void Update()
    {
        theTime += Time.deltaTime;

        var map = mapJson.map;

        if (theTime > map.highScore) {
            map.highScore = theTime;
            string mapData = JsonUtility.ToJson(map);
            string path = Application.dataPath + "/Resources/Maps/" + MapChange.selectedMap + "/properties.json";
            System.IO.File.WriteAllText(path, mapData);
        }
    }
}
