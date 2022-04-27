using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChange : MonoBehaviour
{
    public Image map;

    public Sprite map1;
    public Sprite map2;
    public Sprite map3;
    public Sprite map4;

    public static bool map1Selected = true;
    public static bool map2Selected = false;
    public static bool map3Selected = false;
    public static bool map4Selected = false;

    public Animator animator;
    bool mapsBar = false;

    public static string selectedMap = "Map 1";

    public void Maps()
    {
        if (!mapsBar)
        {
            animator.SetTrigger("Maps In");
            mapsBar = true;
        }
        else
        {
            animator.SetTrigger("Maps Out");
            mapsBar = false;
        }
    }

    void Update() {
        var mapSprite = Resources.Load<Sprite>("Maps/" + selectedMap + "/map");
        map.sprite = mapSprite;
    }
}
