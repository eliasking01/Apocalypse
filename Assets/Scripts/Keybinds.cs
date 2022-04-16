using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinds : MonoBehaviour
{
    [Header ("Keybinds")]
    public KeyCode shoot;
    public KeyCode shotgun;
    public KeyCode sniper;
    public KeyCode turret;
    public KeyCode rocket;
    public KeyCode box;
    public KeyCode reload;
    public KeyCode buyMenu;
    public KeyCode pauseMenu;

    public static KeyCode shootKey;
    public static KeyCode shotgunKey;
    public static KeyCode sniperKey;
    public static KeyCode turretKey;
    public static KeyCode rocketKey;
    public static KeyCode boxKey;
    public static KeyCode reloadKey;
    public static KeyCode buyMenuKey;
    public static KeyCode pauseMenuKey;

    void Start()
    {
        shootKey = shoot;
        shotgunKey = shotgun;
        sniperKey = sniper;
        turretKey = turret;
        rocketKey = rocket;
        boxKey = box;
        reloadKey = reload;
        buyMenuKey = buyMenu;
        pauseMenuKey = pauseMenu;
    }
}
