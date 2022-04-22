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

    public void Start()
    {
        if (map1Selected) {map.sprite = map1;}
        if (map2Selected) {map.sprite = map2;}
        if (map3Selected) {map.sprite = map3;}
        if (map4Selected) {map.sprite = map4;}
    }

    public void Map_1()
    {
        select("map1");
        map.sprite = map1;
    }

    public void Map_2()
    {
        select("map2");
        map.sprite = map2;
    }

    public void Map_3()
    {
        select("map3");
        map.sprite = map3;
    }

    public void Map_4()
    {
        select("map4");
        map.sprite = map4;
    }

    void select(string map)
    {
        // map 1
        if (map == "map1")
        {
            map1Selected = true;
        }
        else
        {
            map1Selected = false;
        }

        // map 2
        if (map == "map2")
        {
            map2Selected = true;
        }
        else
        {
            map2Selected = false;
        }

        // map 3
        if (map == "map3")
        {
            map3Selected = true;
        }
        else
        {
            map3Selected = false;
        }

        // map 3
        if (map == "map4")
        {
            map4Selected = true;
        }
        else
        {
            map4Selected = false;
        }
    }
}
