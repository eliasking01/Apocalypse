using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class Bullet : MonoBehaviour
{	
	public GameObject hitEffect;
	public GameObject Blood;
	public GameObject Hit;
	public GameObject BlueBlood;

	public static float shotsFired = 0;
	public static float hitsThisGame = 0;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Map")
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Enemy")
		{
			if (gameObject.tag == "Bullet")
			{
				hitsThisGame++;

				// online
				if (PlayerStats.steamStats && SteamManager.Initialized)
				{
					SteamUserStats.GetStat("hitsAllTime", out int hitsAllTime);
					hitsAllTime++;
					SteamUserStats.SetStat("hitsAllTime", hitsAllTime);

					SteamUserStats.StoreStats();
				}
				// offline
				else
				{
					int hitsAllTime = PlayerPrefs.GetInt("hitsAllTime", 0);
					hitsAllTime++;

					PlayerPrefs.SetInt("hitsAllTime", hitsAllTime);
				}
			}

			GameObject effect = Instantiate(Blood, transform.position, Quaternion.identity);
			GameObject effect1 = Instantiate(Hit, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			Destroy(effect1, 5f);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Player")
		{
			GameObject effect = Instantiate(BlueBlood, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Friendly")
		{
			GameObject effect = Instantiate(BlueBlood, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Turret")
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Box")
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			Destroy(gameObject);
		}
	}
}
