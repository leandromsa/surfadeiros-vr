using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    public float boardSpeed = 3f;
    public float boardHandle = 12f;
    [SerializeField]
    GameObject boardObject;

    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // LOCOMOTION
        var camRight = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z);
        var camForward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        
        Debug.Log(Camera.main.transform.rotation.eulerAngles.z);
        
        float headTilt = 0f;
         if(Between(Camera.main.transform.rotation.eulerAngles.z, 0, 30)) {
             headTilt = -Camera.main.transform.rotation.eulerAngles.z;
         }
         if(Between(Camera.main.transform.rotation.eulerAngles.z, 31, 180)) {
             headTilt = -30;
         }

         if(Between(Camera.main.transform.rotation.eulerAngles.z, 330, 360)) {
             headTilt = -(Camera.main.transform.rotation.eulerAngles.z - 360);
         }

          if(Between(Camera.main.transform.rotation.eulerAngles.z, 181, 330)) {
             headTilt = 30;
         }
        headTilt *= 0.1f;

        _rb.velocity = camForward * boardSpeed  + camRight * headTilt * boardHandle;

        _rb.velocity += Vector3.down * 9.8f;

        // ROTATION OF THE BOARD
        Vector3 eulerRotation = new Vector3(boardObject.transform.eulerAngles.x,  Camera.main.transform.eulerAngles.y + 90, boardObject.transform.eulerAngles.z);
        boardObject.transform.rotation = Quaternion.Euler(eulerRotation);
    }

    public static bool Between(float number, float min, float max)
{
    return number >= min && number <= max;
}
}
