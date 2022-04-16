using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAiHealth : MonoBehaviour
{
    public float health = 100;
    public GameObject Poof;

    void Start()
    {
        health = 100;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(Poof, transform.position, Quaternion.identity);
            Currency.currency += 50;
            Shooting.ammo += 30;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 15;
        }

        if (collision.gameObject.tag == "SniperBullet")
        {
            health -= 85;
        }

        if (collision.gameObject.tag == "Explosion")
        {
            health -= 80;
        }

        if (collision.gameObject.tag == "TurretBullet")
        {
            health -= 40;
        }

        if (collision.gameObject.tag == "Rocket")
        {
            health -= 30;
        }

        if (collision.gameObject.tag == "ShotgunBullet")
        {
            health -= 30;
        }
    }
}
