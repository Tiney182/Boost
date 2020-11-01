using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketMovement : MonoBehaviour
{

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    Rigidbody rigidbody;
    AudioSource audio;

    enum State {ALIVE, DYING, TRANSENDING}
    private State state = State.ALIVE;
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

    void OnCollisionEnter(Collision collision)
    {
        if(state != State.ALIVE) {
            return;
        }
        if (collision.gameObject.tag.Equals("Friendly"))
        {
        }
        else if (collision.gameObject.tag.Equals("Finish"))
        {
            state = State.TRANSENDING;
            Invoke("LoadNextLevel", 1f);
        }
        else
        {
            state = State.DYING;
            Invoke("LoadFirstLevel", 1f);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
        state = State.ALIVE;
    }

       private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
        state = State.ALIVE;
    }

    private void ResetPosition()
    {
        if (Input.GetKey(KeyCode.R))
        {
            gameObject.transform.position = originalPos;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
    }
    private void HandleThrust()
    {
        if(state != State.ALIVE) {
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
        }
        else
        {
            audio.Stop();
        }
    }

    private void HandleRotation()
    {
        if(state != State.ALIVE) {
            return;
        }
        rigidbody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        rigidbody.freezeRotation = false;
    }
}
