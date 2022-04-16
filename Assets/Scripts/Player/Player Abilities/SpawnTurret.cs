using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurret : MonoBehaviour
{
	public GameObject TurretPrefab;

	public Transform spawnPoint;

	public GameObject spawnEffect;

	public float cooldownTime = 2;

	private float nextSpawnTime = 100;

	public bool didOnce;

	void Update()
	{
		if(didOnce == false)
		{			
			if (!PauseMenu.GameIsPaused)
			{
				if (Input.GetKeyDown(Keybinds.turretKey))
				{
					Spawn();
				}
			}
		}
	}

	void Spawn()
	{
		if (Time.timeSinceLevelLoad > nextSpawnTime)
		{
			nextSpawnTime = Time.time + cooldownTime;

			Instantiate(TurretPrefab, spawnPoint.position, spawnPoint.rotation);
			Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation);

			AstarPath.active.Scan();

			didOnce = true;
		}
	}
}
