using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + Camera.main.transform.forward * 0.02f;
        //transform.Rotate(0f, Input.acceleration.x * acceleratorSensitivity, 0f);
        //Debug.Log(Input.acceleration.x);
        //Debug.Log( Mathf.Clamp(Camera.main.transform.rotation.z, -10 ,10) * 2f);
        _rb.velocity = new Vector3(-Mathf.Clamp(Camera.main.transform.rotation.z, -30 ,30) * 4f, 0, 1f);
        //_rb.velocity = new Vector3(0, 0, 2f);
        //transform.position = transform.position + Camera.main.transform.forward * 0.02f;
        //transform.position = transform.position + Camera.main.transform.right * Input.acceleration.x * 0.2f;
    }
}
