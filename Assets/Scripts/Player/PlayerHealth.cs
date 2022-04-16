using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100;

    public static float regenRate;

    public HealthProgress healthProgress;

    public GameObject ghostSound;

    public GameObject deathSound;

    public static bool dead;

    float elapsed = 0f;
    
    void Start()
    {
        regenRate = 1;
        health = 100;
        dead = false;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathSound, transform.position, Quaternion.identity);
            Time.timeScale = 0f;
            dead = true;
        }

        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            OutputTime();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 2;
        }

        if (collision.gameObject.tag == "Explosion")
        {
            health -= 1;
        }

        healthProgress.current = health;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TurretBullet")
        {
            health -= 5;
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            health -= 10;
        }

        if (collision.gameObject.tag == "Rocket")
        {
            health -= 10;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            health -= 2;
        }

        healthProgress.current = health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            health -= 25;
            Instantiate(ghostSound, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.tag == "DarkGhost")
        {
            health -= 35;
            Instantiate(ghostSound, transform.position, Quaternion.identity);
        }

        healthProgress.current = health;
    }

    void OutputTime()
    {
        if (health < 100)
        {
            health += regenRate;

            healthProgress.current = health;
        }
    }
}
