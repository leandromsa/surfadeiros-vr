using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    public float boardSpeed = 3f;
    public float boardHandle = 12f;

    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var camRight = new Vector3(Camera.main.transform.right.x,0f, Camera.main.transform.right.z);
        var camForward = new Vector3(Camera.main.transform.forward.x,0f, Camera.main.transform.forward.z);
        _rb.velocity = camForward * boardSpeed  + camRight * -Mathf.Clamp(Camera.main.transform.rotation.z, -30 ,30) * boardHandle;
    }
}
