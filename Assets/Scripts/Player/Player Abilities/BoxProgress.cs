using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class BoxProgress : MonoBehaviour
{
    float current;

    public Image mask;
    public Image fill;
    public Color color;

    // lerp
    float timeElapsed;
    float lerpDuration = 60;

    // fills in the progress bar
    void GetCurrentFill()
    {
        float fillAmount = current;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }

    void Update()
    {
        // changes the current value of the progress bar and restarts it once it reaches the maximum value
        if (timeElapsed < lerpDuration)
        {
            current = Mathf.Lerp(0, 1, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
            SpawnBox.boxCount++;
        }

        GetCurrentFill();
    }
}
