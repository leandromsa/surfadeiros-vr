﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrackScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLocomotion>())
        {
            other.GetComponent<PlayerLocomotion>().isRunning = false;

        }
       
    }
}
