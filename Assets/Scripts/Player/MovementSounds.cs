using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSounds : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            audioSource.Pause();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
            }
        }       
    }
}
