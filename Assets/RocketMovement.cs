﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput() {
        if (Input.GetKey(KeyCode.Space)) {
            print("Space pressed");
        } else if (Input.GetKey(KeyCode.A)) {
            print("Left pressed");
        } else if (Input.GetKey(KeyCode.D)) {
            print("Right pressed");
        }
    }
}
