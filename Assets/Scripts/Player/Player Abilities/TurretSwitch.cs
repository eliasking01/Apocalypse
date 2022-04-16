using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSwitch : MonoBehaviour
{
    public Transform firePoint;

    public Transform firePoint2;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float cooldownTime = 2;

    private float nextFireTime = 0;

    public GameObject shootSound;

    public GameObject shootEffect;

    public Animator shootAnim;

    public Animator shootAnim2;

    public static bool switched;

    public bool fired;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switched = true;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            switched = false;
        }

        if (fired == false)
        {
            if (switched == true)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
            }
        }

        if (fired == true)
        {
            if (switched == true)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot2();
                }
            }
        }

        if (switched == true)
        {
            // rotates the turret towards the mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void Shoot()
    {
        if (Time.time > nextFireTime && !PauseMenu.GameIsPaused && !PauseMenu.buyMenuOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextFireTime = Time.time + cooldownTime;
            }

            GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            GameObject sound = Instantiate(shootSound, firePoint2.position, firePoint2.rotation);
            GameObject effect = Instantiate(shootEffect, firePoint2.position, firePoint2.rotation);
            Destroy(effect, 5f);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            shootAnim.SetTrigger("Shoot");

            fired = true;
        }
    }

    void Shoot2()
    {
        if (Time.time > nextFireTime && !PauseMenu.GameIsPaused && !PauseMenu.buyMenuOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextFireTime = Time.time + cooldownTime;
            }

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject sound = Instantiate(shootSound, firePoint.position, firePoint.rotation);
            GameObject effect = Instantiate(shootEffect, firePoint.position, firePoint.rotation);
            Destroy(effect, 5f);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            shootAnim2.SetTrigger("Shoot");

            fired = false;
        }
    }
}
