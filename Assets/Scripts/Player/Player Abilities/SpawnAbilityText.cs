using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbilityText : MonoBehaviour
{
    public GameObject AbilityCanvas;
    bool did = false;

    void Update()
    {
        if (Time.timeSinceLevelLoad >= Shooting.delay)
        {
            if (!PlayerHealth.dead)
            {
                if (did == false)
                {
                    Instantiate(AbilityCanvas);
                    did = true;
                }             
            }
        }
    }
}
