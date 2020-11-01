using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            if(!particleSystem.isPlaying) {
                particleSystem.Play();
            } 
            particleSystem.Stop();
        }
    }
}
