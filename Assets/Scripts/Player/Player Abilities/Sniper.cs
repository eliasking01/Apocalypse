
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
	[Header ("Bullet")]
	public Transform firePoint;
	public GameObject bulletPrefab;
	public float fireRate;
	public float bulletForce = 20f;

	[Header ("Effects")]
	public GameObject shootSound;
	public GameObject shootEffect;

	[Header ("Animations")]
	public Animator shootAnim;

	[Header ("Camera")]
	public Camera OrthographicCamera;
	public float camSize;
	float defaultCamSize;

	float shootTime;

	Rigidbody2D rb;

	public static bool enabled;

	void Start()
	{
		enabled = false;

		defaultCamSize = OrthographicCamera.orthographicSize;
		shootTime = fireRate;
	}

    void Update()
	{
		shootTime += Time.deltaTime;

		if (Input.GetKey(Keybinds.sniperKey) && !Input.GetKey(Keybinds.shotgunKey) && !TurretSwitch.switched && !PauseMenu.GameIsPaused && enabled)
		{
			if (Input.GetKeyDown(Keybinds.shootKey))
			{	
				Shoot();
			}

			if (shootTime < fireRate)
			{
				OrthographicCamera.orthographicSize = defaultCamSize;
			}
			else
			{
				OrthographicCamera.orthographicSize = camSize;
			}
		}
		else
		{
			OrthographicCamera.orthographicSize = defaultCamSize;
		}
	}

	void Shoot()
	{
		if (shootTime >= fireRate)
		{
			shootTime = 0;

			GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			Instantiate(shootSound, firePoint.position, firePoint.rotation);

			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

			rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

			shootAnim.SetTrigger("Shoot");
		}
	}
}
