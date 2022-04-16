using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTint : MonoBehaviour
{
    float value;
    public Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        value = (100 - PlayerHealth.health) / 255;
        image.color = new Color(image.color.r, image.color.g, image.color.b, value / 2);
    }
}
