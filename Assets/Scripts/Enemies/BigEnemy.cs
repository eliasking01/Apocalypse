using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    float maxHealth = 400;
    public float currentHealth;
    bool didnotdie = true;

    public GameObject BigPoof;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(BigPoof, transform.position, Quaternion.identity);

            if (didnotdie == true)
            {
                if (PlayerHealth.health <= 80)
                {
                    PlayerHealth.health += 20;
                    Currency.currency += 100;
                }
                else
                {
                    PlayerHealth.health = 100;
                }

                didnotdie = false;
            }

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 20;
        }

        if (collision.gameObject.tag == "SniperBullet")
        {
            currentHealth -= 95;
        }

        if (collision.gameObject.tag == "Explosion")
        {
            currentHealth -= 130;
        }

        if (collision.gameObject.tag == "TurretBullet")
        {
            currentHealth -= 50;
        }

        if (collision.gameObject.tag == "Rocket")
        {
            currentHealth -= 55;
        }

        if (collision.gameObject.tag == "ShotgunBullet")
        {
            currentHealth -= 15;
        }
    }
}
