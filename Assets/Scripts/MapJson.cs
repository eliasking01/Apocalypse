
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapJson : MonoBehaviour
{
    private static MapJson _instance;
 
    public static MapJson instance
    {
        get    
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
        
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<MapJson>();
            return _instance;
        }
    }

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

    public static T ImportJson<T>(string path)
    {
        string jsonString = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(jsonString);
    }

    public void Reset() {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Documents/Apocalypse Maps";
        string[] mapNames = Directory.GetDirectories(path);

        for (int i = 0; i < mapNames.Length; i++) {
            map = ImportJson<Map>(mapNames[i] + "/properties.json");
            map.highScore = 0;

            string mapData = JsonUtility.ToJson(map);
            System.IO.File.WriteAllText(mapNames[i] + "/properties.json", mapData);
        }
    }

    async void Awake() {
        ScanAll();
    }

    void ScanAll() {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Documents/Apocalypse Maps/" + MapChange.selectedMap;
        map = ImportJson<Map>(path + "/properties.json");

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Game") {
            // loads the sprite and adds a collider
            string transparentPath = path + "/transparent.png";
            var gameMapSprite = IMG2Sprite.instance.LoadNewSprite(transparentPath);
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

            // changes the positions of the spawn points
            for (int i=0; i<10; i++)
            {
                GameObject spawn = GameObject.Find("Spawns/Spawn " + (i + 1));
                spawn.transform.position = map.enemies.spawns[i];
            }

            AstarPath.active.Scan();
        } else if (sceneName == "Menu") {
            string[] mapNames = Directory.GetDirectories(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Documents/Apocalypse Maps");

            for (int i = 0; i < mapNames.Length; i++)
            {
                string mapName = mapNames[i].Replace(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Documents/Apocalypse Maps/", "");

                // sets the thumbnail's position
                GameObject mapButton = Instantiate(mapPlay);
                mapButton.name = mapName;
                mapButton.transform.parent = mapPlayParent.transform;
                RectTransform mapRectTransform = mapButton.GetComponent<RectTransform>();
                mapRectTransform.anchoredPosition = new Vector2(0, -127 - (224 * i));
                mapButton.transform.localScale = new Vector2(0.13f, 0.13f);

                // increases the map container height
                RectTransform containerRect = mapPlayParent.GetComponent<RectTransform>();
                containerRect.sizeDelta = new Vector2(containerRect.rect.width, 500 + (224 * i));

                // sets the sprite of the thumbnail
                var thumbnailSprite = IMG2Sprite.instance.LoadNewSprite(mapNames[i] + "/thumbnail.png");

                Image thumbnailImage = mapButton.GetComponent<Image>();
                thumbnailImage.sprite = thumbnailSprite;

                // changes map name text
                Text mapNameText = GameObject.Find("Canvas/Maps Scroll/Maps Container/" + mapName + "/Panel/Map Name").GetComponent<Text>();
                mapNameText.text = mapName.ToUpper();
            }
        }
    }

    public void ScanMap() {
        string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Documents/Apocalypse Maps/" + MapChange.selectedMap;
        map = ImportJson<Map>(path + "/properties.json");
    }
}
