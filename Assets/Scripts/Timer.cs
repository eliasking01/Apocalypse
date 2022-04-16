using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class Timer : MonoBehaviour
{
    public static float theTime;

    bool a;

    void Start()
    {
        a = true;
        theTime = 0;
    }

    string ToTime(int time)
    {
        string hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        return hours + ":" + minutes + ":" + seconds;
    }

    int Max(int[] arr)
    {
        int max = 0;

        for (int x = 0; x < arr.Length; x++)
        {
            if (arr[x] > max)
            {
                max = arr[x];
            }
        }

        return max;
    }

    int Sum(int[] arr)
    {
        int sum = 0;

        for (int x = 0; x < arr.Length; x++)
        {
            sum += arr[x];
        }

        return sum;
    }

    void Update()
    {
        theTime += Time.deltaTime;

        if (PlayerStats.steamStats && SteamManager.Initialized)
        {
            SteamUserStats.GetStat("highScoreMap1", out int hs1);
            SteamUserStats.GetStat("highScoreMap2", out int hs2);
            SteamUserStats.GetStat("highScoreMap3", out int hs3);

            if (MapChange.map1Selected && Mathf.FloorToInt(theTime) > hs1)
            {
                SteamUserStats.SetStat("highScoreMap1", Mathf.FloorToInt(theTime));
            }
            else if (MapChange.map2Selected && Mathf.FloorToInt(theTime) > hs2)
            {
                SteamUserStats.SetStat("highScoreMap2", Mathf.FloorToInt(theTime));
            }
            else if (MapChange.map3Selected && Mathf.FloorToInt(theTime) > hs3)
            {
                SteamUserStats.SetStat("highScoreMap3", Mathf.FloorToInt(theTime));
            }

            // counts the number of games played in each map
            if (theTime > 10 && a)
            {
                // "a" makes sure this only happens once
                a = false;
                int games1;
                int games2;
                int games3;

                SteamUserStats.GetStat("gamesPlayedMap1", out games1);
                SteamUserStats.GetStat("gamesPlayedMap2", out games2);
                SteamUserStats.GetStat("gamesPlayedMap3", out games3);
                
                if (MapChange.map1Selected)
                {
                    games1++;
                    SteamUserStats.SetStat("gamesPlayedMap1", games1);
                }
                else if (MapChange.map2Selected)
                {
                    games2++;
                    SteamUserStats.SetStat("gamesPlayedMap2", games2);
                }
                else if (MapChange.map3Selected)
                {
                    games3++;
                    SteamUserStats.SetStat("gamesPlayedMap3", games3);
                }

                int[] gamesArr = {games1, games2, games3};
                SteamUserStats.SetStat("totalGamesPlayed", Sum(gamesArr));
            }

            // updates the all time high score
            int[] hsArr = {hs1, hs2, hs3};
            int hsAllTime = Max(hsArr);
            SteamUserStats.SetStat("highScoreAllTime", hsAllTime);

            // achievements
            if (theTime >= 60)
            {
                SteamUserStats.SetAchievement("SURVIVE_ONE_MINUTE_ANY_MAP");
            }
            if (theTime >= 300)
            {
                SteamUserStats.SetAchievement("SURVIVE_FIVE_MINUTES_ANY_MAP");
            }
            if (theTime >= 600)
            {
                SteamUserStats.SetAchievement("SURVIVE_TEN_MINUTES_ANY_MAP");
            }

            SteamUserStats.StoreStats();
        }

        // offline
        else
        {
            // sets the high score values
            if (MapChange.map1Selected && theTime > PlayerPrefs.GetFloat("HighScoreTimeMap1", 0))
            {
                PlayerPrefs.SetFloat("HighScoreTimeMap1", theTime);
                PlayerPrefs.SetString("HighScoreMap1", ToTime(Mathf.FloorToInt(theTime)));
            }
            else if (MapChange.map2Selected && theTime > PlayerPrefs.GetFloat("HighScoreTimeMap2", 0))
            {
                PlayerPrefs.SetFloat("HighScoreTimeMap2", theTime);
                PlayerPrefs.SetString("HighScoreMap2", ToTime(Mathf.FloorToInt(theTime)));
            }
            else if (MapChange.map3Selected && theTime > PlayerPrefs.GetFloat("HighScoreTimeMap3", 0))
            {
                PlayerPrefs.SetFloat("HighScoreTimeMap3", theTime);
                PlayerPrefs.SetString("HighScoreMap3", ToTime(Mathf.FloorToInt(theTime)));
            }

            // counts the number of games played in each map
            if (theTime > 10 && a)
            {
                // "a" makes sure this only happens once every game
                a = false;

                int games1 = PlayerPrefs.GetInt("gamesPlayedMap1", 0);
                int games2 = PlayerPrefs.GetInt("gamesPlayedMap2", 0);
                int games3 = PlayerPrefs.GetInt("gamesPlayedMap3", 0);
                
                if (MapChange.map1Selected)
                {
                    games1++;
                    PlayerPrefs.SetInt("gamesPlayedMap1", games1);
                }
                else if (MapChange.map2Selected)
                {
                    games2++;
                    PlayerPrefs.SetInt("gamesPlayedMap2", games2);
                }
                else if (MapChange.map3Selected)
                {
                    games3++;
                    PlayerPrefs.SetInt("gamesPlayedMap3", games3);
                }

                int[] gamesArr = {games1, games2, games3};
                PlayerPrefs.SetInt("totalGamesPlayed", Sum(gamesArr));
            }

            // all time high score
            int hs1 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScoreTimeMap1", 0));
            int hs2 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScoreTimeMap2", 0));
            int hs3 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScoreTimeMap3", 0));

            int[] hsArr = {hs1, hs2, hs3};
            int hsAllTime = Max(hsArr);
            PlayerPrefs.SetInt("allTimeHighScore", hsAllTime);
        }
    }
}
