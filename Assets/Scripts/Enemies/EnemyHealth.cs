using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float maxHealth = 100;
    float currentHealth;
    bool didnotdie = true;
    public GameObject Poof;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(Poof, transform.position, Quaternion.identity);

            if (didnotdie == true)
            {
                Currency.currency += 20;
                didnotdie = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 25;
            Currency.currency += 5;
        }

        if (collision.gameObject.tag == "SniperBullet")
        {
            currentHealth -= 100;
            Currency.currency += 10;
        }

        if (collision.gameObject.tag == "Explosion")
        {
            currentHealth -= 100;
            Currency.currency += 10;
        }

        if (collision.gameObject.tag == "TurretBullet")
        {
            currentHealth -= 60;
            Currency.currency += 10;
        }

        if (collision.gameObject.tag == "Rocket")
        {
            currentHealth -= 55;
            Currency.currency += 10;
        }

        if (collision.gameObject.tag == "ShotgunBullet")
        {
            currentHealth -= 30;
            Currency.currency += 5;
        }
    }
}
