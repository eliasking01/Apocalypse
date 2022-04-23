using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform spawn1, spawn2, spawn3, spawn4, spawn5, spawn6, spawn7, spawn8, spawn9, spawn10;
    public GameObject enemy, bigEnemy, ghost, darkGhost, shootingEnemy, friendly;

    [Header ("Effects")]
    public GameObject spawnEffect;

    [Header ("Timings")]
    float timeBetweenSpawns = 3.5f;
    float friendlyTimeBetweenSpawns;
    float timeDecreaseRate = 0.003f;
    float timer;
    float friendlyTimer;

    MapJson MapJson;
    MapJson.Map map = new MapJson.Map();

    void Start()
    {
        map = MapJson.map;
        
        timeBetweenSpawns = map.enemies.timeBetween;
        timeDecreaseRate = map.enemies.timeDecreaseRate;
        friendlyTimeBetweenSpawns = 50;
        timer = 0;
    }

    void Update()
    {
        Debug.Log(map.player.maxHealth);

        timer += Time.deltaTime;
        friendlyTimer += Time.deltaTime;

        timeBetweenSpawns -= timeDecreaseRate * Time.deltaTime;
        
        // friendly
        if (friendlyTimer >= friendlyTimeBetweenSpawns && !PlayerHealth.dead && Time.timeSinceLevelLoad >= 270)
        {
            friendlyTimer = 0;
            int spawnLocationNum = Random.Range(0, 10);

            bool spawnOrNot = Random.Range(1, 3) == 1;

            GameObject spawnEnemy = friendly;

            // finds the spawn location and spawns the friendly
            if (spawnOrNot)
            {
                switch (spawnLocationNum) {
                    case 0:
                        Instantiate(spawnEnemy, map.enemies.spawns[0], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[0], Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(spawnEnemy, map.enemies.spawns[1], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[1], Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(spawnEnemy, map.enemies.spawns[2], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[2], Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(spawnEnemy, map.enemies.spawns[3], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[3], Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(spawnEnemy, map.enemies.spawns[4], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[4], Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(spawnEnemy, map.enemies.spawns[5], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[5], Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(spawnEnemy, map.enemies.spawns[6], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[6], Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(spawnEnemy, map.enemies.spawns[7], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[7], Quaternion.identity);
                        break;
                    case 8:
                        Instantiate(spawnEnemy, map.enemies.spawns[8], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[8], Quaternion.identity);
                        break;
                    case 9:
                        Instantiate(spawnEnemy, map.enemies.spawns[9], Quaternion.identity);
                        Instantiate(spawnEffect, map.enemies.spawns[9], Quaternion.identity);
                        break;
                }
            }
        }
        
        // enemy
        if (timer >= timeBetweenSpawns && !PlayerHealth.dead)
        {
            timer = 0;
            int spawnLocationNum = Random.Range(0, 10);
            int spawnEnemyNum = Random.Range(1, 11);

            GameObject spawnEnemy = enemy;

            // finds the enemy to spawn
            if (spawnEnemyNum == 7 && Time.timeSinceLevelLoad >= 180)
            {
                spawnEnemy = ghost;
            }
            else if (spawnEnemyNum == 8 && Time.timeSinceLevelLoad >= 300)
            {
                spawnEnemy = shootingEnemy;
            }
            else if (spawnEnemyNum == 9 && Time.timeSinceLevelLoad >= 420)
            {
                spawnEnemy = bigEnemy;
            }
            else if (spawnEnemyNum == 10 && Time.timeSinceLevelLoad >= 540)
            {
                spawnEnemy = darkGhost;
            }

            // finds the spawn location and spawns the enemy
            switch (spawnLocationNum) {
                case 0:
                    Instantiate(spawnEnemy, map.enemies.spawns[0], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[0], Quaternion.identity);
                    break;
                case 1:
                    Instantiate(spawnEnemy, map.enemies.spawns[1], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[1], Quaternion.identity);
                    break;
                case 2:
                    Instantiate(spawnEnemy, map.enemies.spawns[2], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[2], Quaternion.identity);
                    break;
                case 3:
                    Instantiate(spawnEnemy, map.enemies.spawns[3], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[3], Quaternion.identity);
                    break;
                case 4:
                    Instantiate(spawnEnemy, map.enemies.spawns[4], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[4], Quaternion.identity);
                    break;
                case 5:
                    Instantiate(spawnEnemy, map.enemies.spawns[5], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[5], Quaternion.identity);
                    break;
                case 6:
                    Instantiate(spawnEnemy, map.enemies.spawns[6], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[6], Quaternion.identity);
                    break;
                case 7:
                    Instantiate(spawnEnemy, map.enemies.spawns[7], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[7], Quaternion.identity);
                    break;
                case 8:
                    Instantiate(spawnEnemy, map.enemies.spawns[8], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[8], Quaternion.identity);
                    break;
                case 9:
                    Instantiate(spawnEnemy, map.enemies.spawns[9], Quaternion.identity);
                    Instantiate(spawnEffect, map.enemies.spawns[9], Quaternion.identity);
                    break;
            }
        }
    }
}
