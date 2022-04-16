using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
	public GameObject hitEffect;

	public GameObject Blood;

	public GameObject Hit;

	public GameObject BlueBlood;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ShotgunBullet")
        {

        }
        else
        {
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "Map")
        {
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);		
		}

		if (collision.gameObject.tag == "Enemy")
		{
			GameObject effect = Instantiate(Blood, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			GameObject effect1 = Instantiate(Hit, transform.position, Quaternion.identity);
			Destroy(effect1, 5f);
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
		}

		if (collision.gameObject.tag == "Box")
		{
			GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
		}
	}
}
