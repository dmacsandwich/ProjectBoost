using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{   
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] float mainThrust = 15;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource rocketThrustAudio;


    // Start is called before the first frame update
    void Start() // initiated at beggining
    {
        rb = GetComponent<Rigidbody>();
        rocketThrustAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust);
            ProcessRocketAudio(true);
        }
        else
        {
            ProcessRocketAudio(false);
        }

    }

    void  ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
            {
                ApplyRotation(rotationThrust);
            }
        else if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-rotationThrust);
            }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame);
        rb.freezeRotation = false; // unfreeze rotation so physics system can take over
    } 

    void ProcessRocketAudio(bool rocketAudio)
    {
        if (rocketAudio)
        {   
            if(!rocketThrustAudio.isPlaying)
            {
                rocketThrustAudio.PlayOneShot(mainEngine);
            }
        }
        else
        {
            rocketThrustAudio.Stop();
        }

    }
}
