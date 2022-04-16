using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public static float currency;
    public Transform currencyText;

    public static bool disableRegen;
    public static bool disableSpeed;
    public static bool disableFireRate;
    public static bool disableShotgun;
    public static bool disableSniper;

    public GameObject buySound;

    void Start()
    {
        currency = 300;

        disableFireRate = false;
        disableRegen = false;
        disableSpeed = false;
        disableShotgun = false;
        disableSniper = false;
    }

    public void AmmoBuy()
    {
        if (currency >= 400)
        {
            if (Shooting.ammo <= 999)
            {
                Shooting.ammo += 200;
                currency -= 400;

                Instantiate(buySound);
            }
        }
    }

    public void HealthBuy()
    {
        if (currency >= 400)
        {
            if (PlayerHealth.health <= 75)
            {
                PlayerHealth.health += 25;
                currency -= 400;
                Instantiate(buySound);
            }
            else if (PlayerHealth.health < 100)
            {
                PlayerHealth.health = 100;
                currency -= 400;
                Instantiate(buySound);
            }
        }
    }

    public void RegenBuy()
    {
        if (currency >= 2000)
        {
            PlayerHealth.regenRate = 2;
            currency -= 2000;
            disableRegen = true;

            Instantiate(buySound);
        }
    }

    public void SpeedBuy()
    {
        if (currency >= 2000)
        {
            PlayerMovement.runSpeed = 18;
            currency -= 2000;
            disableSpeed = true;

            Instantiate(buySound);
        }
    }

    public void FireRateBuy()
    {
        if (currency >= 2000)
        {
            Shooting.FireRate = 10;
            currency -= 2000;
            disableFireRate = true;

            Instantiate(buySound);
        }
    }

    public void MagBuy()
    {
        if (currency >= 800)
        {
            Shooting.magCapacity += 10;
            currency -= 800;

            Instantiate(buySound);
        }
    }

    public void ShotgunBuy()
    {
        if (currency < 1500) { return; }
        disableShotgun = true;
        Shotgun.enabled = true;
        currency -= 1500;
    }

    public void SniperBuy()
    {
        if (currency < 1500) { return; }
        disableSniper = true;
        Sniper.enabled = true;
        currency -= 1500;
    }

    public void RocketBuy()
    {
        if (currency < 800) { return; }
        currency -= 800;
        ShootRocket.rocketCount += 1;
    }

    public void BoxBuy()
    {
        if (currency < 800) { return; }
        currency -= 800;
        SpawnBox.boxCount += 1;
    }

    void Update()
    {
        currencyText.GetComponent<Text>().text = currency.ToString();
    }
}
