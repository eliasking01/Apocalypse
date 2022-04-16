using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.UI;

public class SteamUsername : MonoBehaviour
{
    public Text userText;

    void Start()
    {
        if (!SteamManager.Initialized || !PlayerStats.steamStats) { userText.text = "Not signed in".ToUpper(); return; }

        string username = SteamFriends.GetPersonaName();
        userText.text = username.ToUpper();
    }
}
