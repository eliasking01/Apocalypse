// CORRECTED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
	public GameObject hitEffect;
	public GameObject Blood;
	public GameObject Hit;
	public GameObject friendlyBlood;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Map")
		{
			Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Enemy")
		{
			Instantiate(Blood, transform.position, Quaternion.identity);
			Instantiate(Hit, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Player")
		{
			Instantiate(friendlyBlood, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Friendly")
		{
			Instantiate(friendlyBlood, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Turret")
		{
			Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Box")
		{
			Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
