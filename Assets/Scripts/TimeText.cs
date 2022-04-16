using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    public Text text;
    
    string ToTime(int time)
    {
        string hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        return hours + ":" + minutes + ":" + seconds;
    }
    
    void Update()
    {
        text.text = ToTime(Mathf.FloorToInt(Timer.theTime));
    }
}
