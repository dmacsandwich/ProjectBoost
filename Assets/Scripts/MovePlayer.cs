using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{   [SerializeField] float rotationThrust = 1f;
    [SerializeField] float mainThrust = 15;
    Rigidbody rb; 

    // Start is called before the first frame update
    void Start() // initiated at beggining
    {
        rb = GetComponent<Rigidbody>();
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

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame);
        rb.freezeRotation = false; // unfreeze rotation so physics system can take over
    }
    

    }
}
