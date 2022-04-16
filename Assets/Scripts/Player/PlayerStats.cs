using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class PlayerStats : MonoBehaviour
{
    public static string username;
    
    public static bool steamStats = true;

    void Update()
    {
        if (steamStats && SteamManager.Initialized)
        {
            username = SteamFriends.GetPersonaName();
        }
    }
}
