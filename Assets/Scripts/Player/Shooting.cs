using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class Shooting : MonoBehaviour
{
	[Header ("Shooting")]
    public static float FireRate = 7;
	public static bool upgraded;
    public float bulletForce = 20f;

    [Header ("Ammo & Reloading")]
	float reloadSpeed = 0f;
	public float mag = 30;
    public static float ammo = 450;
	public static float magCapacity = 30;
    bool reloading = false;
	public Transform magText;
	public Transform ammoText;

	float withdraw;
	float lastFired;

    [Header ("Gun")]
	public Transform firePoint;
	public GameObject bulletPrefab;

    [Header ("Gun Sounds")]
	public GameObject shootSound;
	public GameObject upgradedShootSound;
	public GameObject reloadSound;

    [Header ("Shoot Effects")]
	public Animator shootAnim;
	public Animator crosshairAnimator;
	public GameObject shootEffect;

	Rigidbody2D sniperBulletRb;

	// stats
	public static int accuracy = 0;

	public static bool hit = false;

    void Start()
    {
		ammo = 450;
		upgraded = false;
		reloadSpeed = 1.5f;
		magCapacity = 30;
		FireRate = 7;

		Bullet.hitsThisGame = 0;
		Bullet.shotsFired = 0;
    }

    void Update()
	{
		if (hit) {
			hit = false;
			Hit();
		}

		if (Bullet.hitsThisGame != 0 && Bullet.shotsFired != 0)
		{
			accuracy = Mathf.RoundToInt((Bullet.hitsThisGame / Bullet.shotsFired) * 100);
		}

		// all time accuracy
		// online
		if (PlayerStats.steamStats && SteamManager.Initialized)
		{
			SteamUserStats.GetStat("hitsAllTime", out float hitsAllTime);
			SteamUserStats.GetStat("shotsFiredAllTime", out float shotsFiredAllTime);

			if (hitsAllTime != 0 && shotsFiredAllTime != 0)
			{
				int allTimeAccuracy = Mathf.RoundToInt((hitsAllTime / shotsFiredAllTime) * 100);
				SteamUserStats.SetStat("accuracyAllTime", allTimeAccuracy);
			}
		}
		// offline
		else
		{
			float hitsAllTime = PlayerPrefs.GetInt("hitsAllTime", 0);
			float shotsFiredAllTime = PlayerPrefs.GetInt("shotsFiredAllTime", 0);

			if (hitsAllTime != 0 && shotsFiredAllTime != 0)
			{
				int allTimeAccuracy = Mathf.RoundToInt((hitsAllTime / shotsFiredAllTime) * 100);
				PlayerPrefs.SetInt("accuracyAllTime", allTimeAccuracy);
			}
		}

		if (upgraded)
        {
			FireRate = 15;
			magCapacity = 60;
			reloadSpeed = 1f;
			bulletForce = 300;
        }

		if (!TurretSwitch.switched && !PauseMenu.GameIsPaused && !PauseMenu.buyMenuOpen && !Input.GetKey(Keybinds.shotgunKey) && !Input.GetKey(Keybinds.sniperKey))
		{
			// reloding while not upgraded
			if (!upgraded && mag != magCapacity && Input.GetKeyDown(Keybinds.reloadKey))
			{
				reloading = true;
				withdraw = (magCapacity - mag);
				Instantiate(reloadSound, firePoint.position, firePoint.rotation);

				if (withdraw >= ammo)
				{
					StartCoroutine(Reload());
				}
				else
				{
					StartCoroutine(Reload1());
				}
			}
			
			// upgraded reloading
			if (upgraded && mag != 60 && Input.GetKeyDown(Keybinds.reloadKey))
			{
				reloading = true;
				withdraw = (magCapacity - mag);
				Instantiate(reloadSound, firePoint.position, firePoint.rotation);

				if (withdraw >= ammo && ammo > 0)
				{
					StartCoroutine(Reload());
				}
				else if (ammo > 0)
				{
					StartCoroutine(Reload1());
				}
			}
			
			// shooting
			if (Input.GetKey(Keybinds.shootKey) && mag > 0 && !reloading && Time.time - lastFired > 1 / FireRate)
			{
				Bullet.shotsFired++;

				// online
				if (PlayerStats.steamStats && SteamManager.Initialized)
				{
					SteamUserStats.GetStat("shotsFiredAllTime", out int shotsFiredAllTime);
					shotsFiredAllTime++;
					SteamUserStats.SetStat("shotsFiredAllTime", shotsFiredAllTime);
				}
				// offline
				else
				{
					int shotsFiredAllTime = PlayerPrefs.GetInt("shotsFiredAllTime", 0);
					shotsFiredAllTime++;

					PlayerPrefs.SetInt("shotsFiredAllTime", shotsFiredAllTime);
				}

				lastFired = Time.time;

				if (upgraded)
				{
					Instantiate(upgradedShootSound, firePoint.position, firePoint.rotation);
				}
				else
				{
					Instantiate(shootSound, firePoint.position, firePoint.rotation);
				}

				GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
				GameObject effect = Instantiate(shootEffect, firePoint.position, firePoint.rotation);
				Destroy(effect, 5f);
				Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
				bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
				shootAnim.SetTrigger("Shoot");
				mag -= 1;
			}
		}

		magText.GetComponent<Text>().text = mag.ToString();
		ammoText.GetComponent<Text>().text = ammo.ToString();

		if (PlayerStats.steamStats && SteamManager.Initialized)
		{
			SteamUserStats.StoreStats();
		}
	}

	IEnumerator Reload()
	{
		mag += ammo;
		ammo = 0;
		yield return new WaitForSeconds(reloadSpeed);
		reloading = false;
	}

	IEnumerator Reload1()
	{
		mag = mag + withdraw;
		ammo = ammo - withdraw;
		yield return new WaitForSeconds(reloadSpeed);
		reloading = false;
	}

	void Hit() {
		crosshairAnimator.SetTrigger("Hit");
	}
}
