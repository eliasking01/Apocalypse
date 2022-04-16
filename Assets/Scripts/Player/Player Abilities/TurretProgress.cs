using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class TurretProgress : MonoBehaviour
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

    void Start()
    {
        gameObject.SetActive(true);

        current = 0;

        if (current == 0)
        {
            Shouldcharge = true;
        }
    }

    void Update()
    {
        GetCurrentFill();

        if (PauseMenu.GameIsPaused)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (current >= 100)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        
        if (Shouldcharge == true)
        {

            if (Input.GetKey(KeyCode.Q))
            {
                current += 1 * Time.deltaTime; // Cap at some max value too
            }
            else
            {
                current += 1 * Time.deltaTime; // Cap at some min value too
            }
        }
    }

    void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            if (PauseMenu.GameIsPaused)
            {

            }
            else
            {
                current = 0;

                if (Input.GetKeyDown(KeyCode.Q))
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
}
