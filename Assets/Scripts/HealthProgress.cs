using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthProgress : MonoBehaviour
{
    float maximum;

    public Image mask;

    public Image fill;

    public Color color;

    MapJson mapJson;

    void Start() {
        mapJson = GameObject.Find("GameObject").GetComponent<MapJson>();
        var map = mapJson.map;

        maximum = map.player.maxHealth;
    }

    void Update()
    {
        float fillAmount = PlayerHealth.health / maximum;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }
}
