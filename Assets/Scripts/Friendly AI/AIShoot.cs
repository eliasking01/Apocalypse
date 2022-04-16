using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    [SerializeField] private float _duration = 0f;

    private float _timer;

    public Transform firePoint;

    public GameObject bulletPrefab;

    public GameObject shootSound;

    public GameObject shootEffect;

    public float bulletForce = 20f;

    Rigidbody2D rb;

    void OnTriggerStay2D(Collider2D target1)
    {
        if (target1.tag == "Enemy")
        {
            if (_timer <= 0)
            {
                _timer = _duration;
                Shoot();
            }

            _timer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject sound = Instantiate(shootSound, firePoint.position, firePoint.rotation);
        GameObject effect = Instantiate(shootEffect, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
