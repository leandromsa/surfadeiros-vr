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
        //transform.Rotate(new Vector3(0, Camera.main.transform.rotation.y,0), Space.World);
        var camRight = new Vector3(Camera.main.transform.right.x,0f, Camera.main.transform.right.z);
        var camForward = new Vector3(Camera.main.transform.forward.x,0f, Camera.main.transform.forward.z);
        _rb.velocity = camForward * 3f  + camRight * -Mathf.Clamp(Camera.main.transform.rotation.z, -30 ,30) * 12f;
        //_rb.velocity = new Vector3(0, 0, 2f);
        //transform.position = transform.position + Camera.main.transform.forward * 0.02f;
        //transform.position = transform.position + Camera.main.transform.right * Input.acceleration.x * 0.2f;
    }
}
