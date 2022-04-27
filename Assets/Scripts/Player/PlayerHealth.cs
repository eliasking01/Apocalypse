using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float health;

    public static float regenRate;

    public GameObject ghostSound;

    public GameObject deathSound;

    public static bool dead;

    float elapsed = 0f;

    MapJson mapJson;
    
    void Start()
    {
        mapJson = GameObject.Find("GameObject").GetComponent<MapJson>();
        var map = mapJson.map;

        regenRate = map.player.regenRate;
        health = map.player.maxHealth;
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
    }

    void OutputTime()
    {
        if (health < 100)
        {
            health += regenRate;
        }
    }
}
