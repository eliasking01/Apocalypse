using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBox : MonoBehaviour
{
    public GameObject boxPrefab;
	public GameObject spawnEffect;
	public Transform spawnPoint;

	public static float boxCount;

	public Text countText;

	void Start()
	{
		boxCount = 1;
	}

	void Update()
	{
        if (!PauseMenu.GameIsPaused)
		{
			if (Input.GetKeyDown(Keybinds.boxKey))
			{
				Spawn();
			}
		}

		countText.text = "x" + boxCount;
	}

	void Spawn()
	{
		if (boxCount > 0)
		{
			boxCount --;

			GameObject box = Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
			GameObject effect = Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation);
			AstarPath.active.Scan();
		}
	}
}
