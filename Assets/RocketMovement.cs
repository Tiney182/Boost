using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    Rigidbody rigidbody;
    AudioSource audio;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
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
        ResetPosition();
    }

    private void ResetPosition() {
        if (Input.GetKey(KeyCode.R)) {
            gameObject.transform.position = originalPos;
            gameObject.transform.rotation = new Quaternion(0,0,0,1);
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

    private void HandleRotation()
    {
        rigidbody.freezeRotation = true;

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

        rigidbody.freezeRotation = false;
    }
}
