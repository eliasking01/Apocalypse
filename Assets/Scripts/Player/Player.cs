using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ability delay
    [Header ("Ability Delay")]
    public float abilityDelay = 5;
    public static float delay;

    // movement
    [Header ("Movement")]
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public static float runSpeed;

    // shooting
    [Header ("Shooting")]
    public static float FireRate = 7;
	public static bool upgraded;
    public float bulletForce = 20f;

    [Header ("Ammo & Reloading")]
	float reloadSpeed = 0f;
	public float mag = 30;
    public static float ammo = 450;
	public static float magCapacity = 30;
    bool reloading = false;
	public Transform magText;
	public Transform ammoText;

	float withdraw;
	float lastFired;

    [Header ("Gun")]
	public Transform firePoint;
	public GameObject bulletPrefab;

    [Header ("Gun Sounds")]
	public GameObject shootSound;
	public GameObject upgradedShootSound;
	public GameObject reloadSound;

    [Header ("Shoot Effects")]
	public Animator shootAnim;
	public GameObject shootEffect;

	public bool turretSwitched;

    Rigidbody2D rb;
    Rigidbody2D bulletRb;

    // sniper
    [Header ("Bullet")]
	public GameObject sniperBulletPrefab;
	public float sniperFireRate;
	public float sniperBulletForce = 20f;

	[Header ("Effects")]
	public GameObject sniperShootSound;

	[Header ("Camera")]
	public Camera OrthographicCamera;
	public float camSize;
	float defaultCamSize;

	float sniperShootTime;

	Rigidbody2D sniperBulletRb;

    void Start()
    {
        // ability delay
        delay = abilityDelay;

        // movement
        runSpeed = 15;
        rb = GetComponent<Rigidbody2D>();

        // shooting
        ammo = 450;
		upgraded = false;
		reloadSpeed = 1.5f;
		magCapacity = 30;
		FireRate = 7;

        bulletRb = bulletPrefab.GetComponent<Rigidbody2D>();

        // sniper
        sniperBulletRb = sniperBulletPrefab.GetComponent<Rigidbody2D>();
		defaultCamSize = OrthographicCamera.orthographicSize;
		sniperShootTime = sniperFireRate;
    }

    void Update()
    {
        // looking
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // shooting
        if (upgraded)
        {
			FireRate = 15;
			magCapacity = 60;
			reloadSpeed = 1f;
			bulletForce = 300;
        }

		if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Space))
		{
			turretSwitched = false;
		}

		if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Space))
		{
			turretSwitched = true;
		}
		
		if (!turretSwitched && !PauseMenu.GameIsPaused)
		{
			// reloding while not upgraded
			if (!upgraded && mag != magCapacity && Input.GetKeyDown(Keybinds.reloadKey))
			{
				reloading = true;
				withdraw = (magCapacity - mag);
				Instantiate(reloadSound, firePoint.position, firePoint.rotation);

				if (withdraw >= ammo)
				{
					StartCoroutine(Reload());
				}
				else
				{
					StartCoroutine(Reload1());
				}
			}
			
			// upgraded reloading
			if (upgraded && mag != 60 && Input.GetKeyDown(Keybinds.reloadKey))
			{
				reloading = true;
				withdraw = (magCapacity - mag);
				Instantiate(reloadSound, firePoint.position, firePoint.rotation);

				if (withdraw >= ammo && ammo > 0)
				{
					StartCoroutine(Reload());
				}
				else if (ammo > 0)
				{
					StartCoroutine(Reload1());
				}
			}
			
			// shooting
			if (Input.GetButton("Fire1") && mag > 0 && !reloading && Time.time - lastFired > 1 / FireRate)
			{
				lastFired = Time.time;

				if (upgraded)
				{
					Instantiate(upgradedShootSound, firePoint.position, firePoint.rotation);
				}
				else
				{
					Instantiate(shootSound, firePoint.position, firePoint.rotation);
				}

				GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
				GameObject effect = Instantiate(shootEffect, firePoint.position, firePoint.rotation);
				Destroy(effect, 5f);
				bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
				shootAnim.SetTrigger("Shoot");
				mag -= 1;
			}
        }

        //magText.GetComponent<Text>().text = mag.ToString();
		//ammoText.GetComponent<Text>().text = ammo.ToString();

        // sniper
        sniperShootTime += Time.deltaTime;

		if (Input.GetKey(Keybinds.sniperKey) && !turretSwitched && !PauseMenu.GameIsPaused && Ability.ChoseSniper && Time.timeSinceLevelLoad >= Player.delay)
		{
			if (Input.GetKeyDown(Keybinds.shootKey))
			{	
				SniperShoot();
			}

			if (sniperShootTime < sniperFireRate)
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

    void SniperShoot()
	{
		if (sniperShootTime >= sniperFireRate)
		{
			sniperShootTime = 0;

			Instantiate(sniperBulletPrefab, firePoint.position, firePoint.rotation);
			Instantiate(shootSound, firePoint.position, firePoint.rotation);

			rb.AddForce(firePoint.up * sniperBulletForce, ForceMode2D.Impulse);

			shootAnim.SetTrigger("Shoot");
		}
	}

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    IEnumerator Reload()
	{
		yield return new WaitForSeconds(reloadSpeed);
        ammo = 0;
        mag += ammo;
		reloading = false;
	}

	IEnumerator Reload1()
	{
		yield return new WaitForSeconds(reloadSpeed);
        mag += withdraw;
		ammo =- withdraw;
		reloading = false;
	}
}
