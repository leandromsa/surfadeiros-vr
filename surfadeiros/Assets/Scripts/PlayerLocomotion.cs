using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    public float boardSpeed = 3f;
    public float accelarationTime = 1f;
    public float boardHandle = 12f;
    [SerializeField]
    GameObject boardObject;

    public float maxBoardSpeed = 40f;

    private float _startTime;
    Rigidbody _rb;

    Vector3 _lastPosition;
    float _velocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _rb = GetComponent<Rigidbody>();
        _lastPosition = transform.position;

        AkSoundEngine.PostEvent("PlayBoardSound", gameObject);
    }

    private void FixedUpdate()
    {
        // SPEED CALCULATION
        _velocity = (transform.position - _lastPosition).magnitude / Time.deltaTime;
        _lastPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // LOCOMOTION
        var camRight = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z);
        var camForward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        
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

      

        //Debug.Log("Velocidade: " + _velocity);  
        AkSoundEngine.SetRTPCValue("boardSpeed", _velocity);

        //float t = (Time.time - _startTime) / accelarationTime;
        //boardSpeed = Mathf.SmoothStep(2, maxBoardSpeed, t);
        //        Debug.Log(boardSpeed);
        boardSpeed = Mathf.Lerp(_velocity, maxBoardSpeed, 1f);

        _rb.velocity = ((camForward * boardSpeed * 1.5f)  + (camRight * headTilt * boardHandle) + new Vector3(0, _rb.velocity.y, 0)) + Vector3.down * 9.8f * Time.deltaTime;
        
        /*if (_rb.velocity.magnitude < boardSpeed) {
            //_rb.AddForce(camForward * boardSpeed, ForceMode.Acceleration);
            //_rb.AddForce(camRight * headTilt * boardHandle, ForceMode.Acceleration);
            //_rb.AddForce(((camForward * boardSpeed) + (camRight * headTilt * boardHandle) + new Vector3(0, _rb.velocity.y, 0)), ForceMode.Acceleration);
         }*/
        


        //_rb.velocity += Vector3.down * 9.8f * Time.deltaTime;

        //Debug.Log(_rb.velocity);

        // ROTATION OF THE BOARD
        Vector3 eulerRotation = new Vector3(boardObject.transform.eulerAngles.x,  Camera.main.transform.eulerAngles.y + 90, boardObject.transform.eulerAngles.z);
        boardObject.transform.rotation = Quaternion.Euler(eulerRotation);
    }

    public static bool Between(float number, float min, float max)
{
    return number >= min && number <= max;
}
}
