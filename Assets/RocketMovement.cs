using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    Rigidbody rigidbody;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        HandleThrust();
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back);
            // rigidbody.AddRelativeForce(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
            // rigidbody.AddRelativeForce(Vector3.left);
        }
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            rigidbody.AddRelativeForce(Vector3.up);
        }
        else
        {
            audio.Stop();
        }
    }
}
