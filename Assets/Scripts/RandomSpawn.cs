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
    float timeBetweenSpawns;
    float friendlyTimeBetweenSpawns;
    float timeDecreaseRate = 0.003f;
    float timer;
    float friendlyTimer;

    void Start()
    {
        timeBetweenSpawns = 3.5f;
        friendlyTimeBetweenSpawns = 50;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        friendlyTimer += Time.deltaTime;

        timeBetweenSpawns -= timeDecreaseRate * Time.deltaTime;
        
        // friendly
        if (friendlyTimer >= friendlyTimeBetweenSpawns && !PlayerHealth.dead && Time.timeSinceLevelLoad >= 270)
        {
            friendlyTimer = 0;
            int spawnLocationNum = Random.Range(1, 11);

            bool spawnOrNot = Random.Range(1, 3) == 1;

            GameObject spawnEnemy = friendly;

            // finds the spawn location and spawns the friendly
            if (spawnOrNot)
            {
                if (spawnLocationNum == 1)
                {
                    Instantiate(spawnEnemy, spawn1.position, spawn1.rotation);
                    Instantiate(spawnEffect, spawn1.position, spawn1.rotation);
                }
                else if (spawnLocationNum == 2)
                {
                    Instantiate(spawnEnemy, spawn2.position, spawn2.rotation);
                    Instantiate(spawnEffect, spawn2.position, spawn2.rotation);
                }
                else if (spawnLocationNum == 3)
                {
                    Instantiate(spawnEnemy, spawn3.position, spawn3.rotation);
                    Instantiate(spawnEffect, spawn3.position, spawn3.rotation);
                }
                else if (spawnLocationNum == 4)
                {
                    Instantiate(spawnEnemy, spawn4.position, spawn4.rotation);
                    Instantiate(spawnEffect, spawn4.position, spawn4.rotation);
                }
                else if (spawnLocationNum == 5)
                {
                    Instantiate(spawnEnemy, spawn5.position, spawn5.rotation);
                    Instantiate(spawnEffect, spawn5.position, spawn5.rotation);
                }
                else if (spawnLocationNum == 6)
                {
                    Instantiate(spawnEnemy, spawn6.position, spawn6.rotation);
                    Instantiate(spawnEffect, spawn6.position, spawn6.rotation);
                }
                else if (spawnLocationNum == 7)
                {
                    Instantiate(spawnEnemy, spawn7.position, spawn7.rotation);
                    Instantiate(spawnEffect, spawn7.position, spawn7.rotation);
                }
                else if (spawnLocationNum == 8)
                {
                    Instantiate(spawnEnemy, spawn8.position, spawn8.rotation);
                    Instantiate(spawnEffect, spawn8.position, spawn8.rotation);
                }
                else if (spawnLocationNum == 9)
                {
                    Instantiate(spawnEnemy, spawn9.position, spawn9.rotation);
                    Instantiate(spawnEffect, spawn9.position, spawn9.rotation);
                }
                else if (spawnLocationNum == 10)
                {
                    Instantiate(spawnEnemy, spawn10.position, spawn10.rotation);
                    Instantiate(spawnEffect, spawn10.position, spawn10.rotation);
                }
            }
        }
        
        // enemy
        if (timer >= timeBetweenSpawns && !PlayerHealth.dead)
        {
            timer = 0;
            int spawnNum = Random.Range(1, 11);
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
            if (spawnNum == 1)
            {
                Instantiate(spawnEnemy, spawn1.position, spawn1.rotation);
                Instantiate(spawnEffect, spawn1.position, spawn1.rotation);
            }
            else if (spawnNum == 2)
            {
                Instantiate(spawnEnemy, spawn2.position, spawn2.rotation);
                Instantiate(spawnEffect, spawn2.position, spawn2.rotation);
            }
            else if (spawnNum == 3)
            {
                Instantiate(spawnEnemy, spawn3.position, spawn3.rotation);
                Instantiate(spawnEffect, spawn3.position, spawn3.rotation);
            }
            else if (spawnNum == 4)
            {
                Instantiate(spawnEnemy, spawn4.position, spawn4.rotation);
                Instantiate(spawnEffect, spawn4.position, spawn4.rotation);
            }
            else if (spawnNum == 5)
            {
                Instantiate(spawnEnemy, spawn5.position, spawn5.rotation);
                Instantiate(spawnEffect, spawn5.position, spawn5.rotation);
            }
            else if (spawnNum == 6)
            {
                Instantiate(spawnEnemy, spawn6.position, spawn6.rotation);
                Instantiate(spawnEffect, spawn6.position, spawn6.rotation);
            }
            else if (spawnNum == 7)
            {
                Instantiate(spawnEnemy, spawn7.position, spawn7.rotation);
                Instantiate(spawnEffect, spawn7.position, spawn7.rotation);
            }
            else if (spawnNum == 8)
            {
                Instantiate(spawnEnemy, spawn8.position, spawn8.rotation);
                Instantiate(spawnEffect, spawn8.position, spawn8.rotation);
            }
            else if (spawnNum == 9)
            {
                Instantiate(spawnEnemy, spawn9.position, spawn9.rotation);
                Instantiate(spawnEffect, spawn9.position, spawn9.rotation);
            }
            else if (spawnNum == 10)
            {
                Instantiate(spawnEnemy, spawn10.position, spawn10.rotation);
                Instantiate(spawnEffect, spawn10.position, spawn10.rotation);
            }
        }
    }
}
