using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Documents/Apocalypse Maps/" + MapChange.selectedMap + "/properties.json";
            System.IO.File.WriteAllText(path, mapData);
        }
    }
}
