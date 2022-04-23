
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapJson : MonoBehaviour
{
    [Serializable]
    public class Map {
        public int highScore;
        public PlayerObj player;
        public EnemiesObj enemies;
    }

    [Serializable]
    public class PlayerObj {
        public Vector2 spawn;
        public int maxHealth;
        public int regenRate;
        public int movementSpeedMultiplier;
        public int currencyMultiplier;
    }

    [Serializable]
    public class EnemiesObj {
        public List<Vector2> spawns;
        public int timeBetween;
        public int timeDecreaseRate;
        public int healthMultiplier;
    }

    public Map map = new Map();

    void Update() {
        map = ImportJson<Map>("Maps/Map 4/properties");
    }

    public static T ImportJson<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonUtility.FromJson<T>(textAsset.text);
    }
}
