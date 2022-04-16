using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
	public float cooldownTime = 2;

	private float nextFireTime = 0;

	public Transform firePoint1;
	public Transform firePoint2;
	public Transform firePoint3;
	public Transform firePoint4;
	public Transform firePoint5;

	public GameObject bulletPrefab;

	public GameObject shootSound;

	public GameObject reloadSound;

	public float bulletForce = 20f;

	public Animator shootAnim;

	public GameObject shootEffect;

	public static bool enabled;

	void Start()
	{
		enabled = false;
	}

	void Update()
	{
		if (!TurretSwitch.switched && enabled && !PauseMenu.GameIsPaused && Input.GetKeyDown(Keybinds.shootKey) && Input.GetKey(Keybinds.shotgunKey) && !Input.GetKey(Keybinds.sniperKey))
		{
			Shoot();
		}	
	}

	void Shoot()
	{
		if (Time.time > nextFireTime)
		{
			nextFireTime = Time.time + cooldownTime;

			GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
			GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
			GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
			GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
			GameObject bullet5 = Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);

			Instantiate(shootSound, firePoint1.position, firePoint1.rotation);
			Instantiate(shootEffect, firePoint1.position, firePoint1.rotation);

			Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
			Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
			Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
			Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
			Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();

			rb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
			rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
			rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
			rb4.AddForce(firePoint4.up * bulletForce, ForceMode2D.Impulse);
			rb5.AddForce(firePoint5.up * bulletForce, ForceMode2D.Impulse);

			shootAnim.SetTrigger("Shoot");
		}
	}
}