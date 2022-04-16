using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;

    public Transform target;
    public GameObject hitEffect;
    public GameObject hitEffect2;
    public GameObject hitSound;

    float timer = 0f;

    public static bool started;

    void Start ()
    {
        started = true;
        target = GameObject.FindGameObjectWithTag("Crosshair").transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
		Destroy(effect, 0.2f);

        GameObject sound = Instantiate(hitSound, transform.position, Quaternion.identity);
        Destroy(sound, 1f);

        GameObject effect2 = Instantiate(hitEffect2, transform.position, Quaternion.identity);
        Destroy(effect2, 5f);

        started = false;
        Destroy(gameObject);
	}

    void Update()
    {
        timer += Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (timer >= 5)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);

            GameObject sound = Instantiate(hitSound, transform.position, Quaternion.identity);
            Destroy(sound, 1f);

            GameObject effect2 = Instantiate(hitEffect2, transform.position, Quaternion.identity);
            Destroy(effect2, 5f);

            started = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Crosshair")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);

            GameObject sound = Instantiate(hitSound, transform.position, Quaternion.identity);
            Destroy(sound, 1f);

            GameObject effect2 = Instantiate(hitEffect2, transform.position, Quaternion.identity);
            Destroy(effect2, 5f);

            started = false;
            Destroy(gameObject);
        }
    }
}
