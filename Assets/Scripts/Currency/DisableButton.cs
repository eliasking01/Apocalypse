using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour
{
    public Button RegenButton;
    public Button SpeedButton;
    public Button FireRateButton;
    public Button ShotgunButton;
    public Button SniperButton;

    void Start()
    {
        RegenButton.interactable = true;
        SpeedButton.interactable = true;
        FireRateButton.interactable = true;
    }

    void Update()
    {
        if (Currency.disableRegen == true)
        {
            RegenButton.interactable = false;
        }

        if (Currency.disableSpeed == true)
        {
            SpeedButton.interactable = false;
        }

        if (Currency.disableFireRate == true)
        {
            FireRateButton.interactable = false;
        }

        if (Currency.disableShotgun == true)
        {
            ShotgunButton.interactable = false;
        }

        if (Currency.disableSniper == true)
        {
            SniperButton.interactable = false;
        }
    }
}
