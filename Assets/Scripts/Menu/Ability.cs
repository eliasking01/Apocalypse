using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public static bool ChoseSniper;
    public static bool ChoseShotgun = true;

    // images
    public Image shotgunImage;
    public Image sniperImage;

    // shotgun sprites
    public Sprite shotgunDefaultSprite;
    public Sprite shotgunHighlightedSprite;

    // sniper sprites
    public Sprite sniperDefaultSprite;
    public Sprite sniperHighlightedSprite;

    void Start()
    {
        if (ChoseShotgun)
        {
            shotgunImage.sprite = shotgunHighlightedSprite;
            sniperImage.sprite = sniperDefaultSprite;
        }
        else if (ChoseSniper)
        {
            sniperImage.sprite = sniperHighlightedSprite;
            shotgunImage.sprite = shotgunDefaultSprite;
        }
    }

    public void ShotGun()
    {
        ChoseShotgun = true;
        ChoseSniper = false;

        shotgunImage.sprite = shotgunHighlightedSprite;
        sniperImage.sprite = sniperDefaultSprite;
    }

    public void Sniper()
    {
        ChoseSniper = true;
        ChoseShotgun = false;

        sniperImage.sprite = sniperHighlightedSprite;
        shotgunImage.sprite = shotgunDefaultSprite;
    }
}
