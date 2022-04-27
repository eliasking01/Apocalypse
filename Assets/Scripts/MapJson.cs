
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapJson : MonoBehaviour
{
    [Serializable]
    public class Map {
        public float highScore;
        public string backgroundColor;
        public string foregroundColor;
        public PlayerObj player;
        public EnemiesObj enemies;
    }

    [Serializable]
    public class PlayerObj {
        public Vector2 spawn;
        public float maxHealth;
        public float regenRate;
        public float movementSpeedMultiplier;
        public float currencyMultiplier;
    }

    [Serializable]
    public class EnemiesObj {
        public List<Vector2> spawns;
        public float timeBetween;
        public float timeDecreaseRate;
        public float healthMultiplier;
    }

    public GameObject gameMap;
    public GameObject background;
    public GameObject mapPlay;
    public GameObject mapPlayParent;

    [HideInInspector] public Map map = new Map();

    string path = "Maps/Map 1";

    string[] prevMaps;
    string[] mapNames;

    bool firstLoad;

    public static T ImportJson<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonUtility.FromJson<T>(textAsset.text);
    }

    void Awake() {
        AssetDatabase.Refresh();

        firstLoad = true;

        path = "Maps/" + MapChange.selectedMap;
        map = ImportJson<Map>(path + "/properties");

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Game") {
            // loads the sprite and adds a collider (WORKING)
            var gameMapSprite = Resources.Load<Sprite>(path + "/transparent");
            SpriteRenderer gameMapSpriteRenderer = gameMap.GetComponent<SpriteRenderer>();
            gameMapSpriteRenderer.sprite = gameMapSprite;
            gameMap.AddComponent<PolygonCollider2D>();

            // sets the background and foreground color
            SpriteRenderer backgroundSpriteRenderer = background.GetComponent<SpriteRenderer>();
            Color color;

            if (ColorUtility.TryParseHtmlString(map.backgroundColor, out color))
            {
                backgroundSpriteRenderer.color = color;
            }

            Camera camera = GameObject.Find("Player/Main Camera").GetComponent<Camera>();

            if (ColorUtility.TryParseHtmlString(map.foregroundColor, out color))
            {
                camera.backgroundColor = color;
            }

            // changes the positions of the spawn points (WORKING)
            for (int i=0; i<10; i++)
            {
                GameObject spawn = GameObject.Find("Spawns/Spawn " + (i + 1));
                spawn.transform.position = map.enemies.spawns[i];
            }

            AstarPath.active.Scan();
        }

        string resourcsPath = Application.dataPath + "/Resources";
        mapNames = Directory.GetDirectories(resourcsPath + "/Maps");
        prevMaps = mapNames;
    }

    void Update() {
        path = "Maps/" + MapChange.selectedMap;
        map = ImportJson<Map>(path + "/properties");

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Menu") {
            string resourcsPath = Application.dataPath + "/Resources";
            mapNames = Directory.GetDirectories(resourcsPath + "/Maps");

            if (mapNames.ToString() != prevMaps.ToString() || firstLoad) {
                firstLoad = false;
                prevMaps = mapNames;

                for (int i = 0; i < mapNames.Length; i++)
                {
                    var mapPath = mapNames[i].Replace(resourcsPath + "/", "");

                    string mapName = mapPath.Replace("Maps/", "");

                    // sets the thumbnail's position
                    GameObject mapButton = Instantiate(mapPlay);
                    mapButton.name = mapName;
                    mapButton.transform.parent = mapPlayParent.transform;
                    RectTransform mapRectTransform = mapButton.GetComponent<RectTransform>();
                    mapRectTransform.anchoredPosition = new Vector2(0, -127 - (224 * i));
                    mapButton.transform.localScale = new Vector2(0.13f, 0.13f);

                    // sets the sprite of the thumbnail (WORKING)
                    var thumbnailSprite = Resources.Load<Sprite>(mapPath + "/thumbnail");

                    Image thumbnailImage = mapButton.GetComponent<Image>();
                    thumbnailImage.sprite = thumbnailSprite;

                    // changes map name text
                    Text mapNameText = GameObject.Find("Canvas/Maps Scroll/Maps Container/" + mapName + "/Panel/Map Name").GetComponent<Text>();
                    mapNameText.text = mapName.ToUpper();
                }
            }
        }
    }
}
