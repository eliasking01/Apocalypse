using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    float timer = 0f;
    float updateTimer;

    public GameObject despawnEffect;

    void Awake()
    {
        AstarPath.active.Scan();
    }

    void Scan()
    {
        AstarPath.active.Scan();
    }

    void Update()
    {
        timer += Time.deltaTime;
        updateTimer += Time.deltaTime;

        if (timer > 15)
        {
            Instantiate(despawnEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Scan();
        }

        if (updateTimer >= 2 && timer <= 15)
        {
            updateTimer = 0;
            Scan();
        }
    }
}

