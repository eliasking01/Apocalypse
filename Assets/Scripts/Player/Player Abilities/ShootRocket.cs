using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootRocket : MonoBehaviour
{
	public Transform firePoint;
	public GameObject rocketPrefab;

	public static int rocketCount;

	public Text countText;

	void Start()
	{
		rocketCount = 1;
	} 

	void Update()
	{
		if (!PauseMenu.GameIsPaused)
		{
			if (Input.GetKeyDown(Keybinds.rocketKey))
			{
				Shoot();
			}
		}

		countText.text = "x" + rocketCount;
	}

	void Shoot()
	{
		if (rocketCount > 0 && !Rocket.started)
		{
			rocketCount --;

			Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
		}
	}
}

