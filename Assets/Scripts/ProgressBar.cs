using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 [ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public float maximum;

    public float minimum;

    public float current;

    public Image mask;

    public Image fill;

    public Color color;

    public float cooldownTime = 2;

    private float nextFireTime = 0;

    public bool Shouldcharge;

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }

        GetCurrentFill();

        if (Shouldcharge == true)
        {
   
            if (Input.GetKey(KeyCode.Q))
            {
                current += 50 * Time.deltaTime;
            }
            else
            {
                current += 50 * Time.deltaTime;
            }            
        }
    }

    void Shoot()
    {       
        if (Time.time > nextFireTime)
        {
            current = 0;

            if (Input.GetMouseButtonDown(1))
            {
                print("cooldown started");
                nextFireTime = Time.time + cooldownTime;
            }

            if (current == 0)
            {
                Shouldcharge = true;
            }
            

            if (current >= 100)
            {
                Shouldcharge = false;
            }
        }
    }
}
