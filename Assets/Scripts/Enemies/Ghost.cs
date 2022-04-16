using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 0.5f);
        }

        if (collision.gameObject.tag == "SniperBullet")
        {
            Destroy(gameObject, 0.3f);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "ShotgunBullet")
        {
            Destroy(gameObject, 0.3f);
        }

        if (collision.gameObject.tag == "TurretBullet")
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
