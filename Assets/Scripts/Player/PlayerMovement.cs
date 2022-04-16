using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

 public class PlayerMovement : MonoBehaviour
 {
    Rigidbody2D body;

    float horizontal;

    float vertical;

    float moveLimiter = 0.7f;

    public static float runSpeed;

    void Start ()
    {
        runSpeed = 15;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
 }
	 

 
