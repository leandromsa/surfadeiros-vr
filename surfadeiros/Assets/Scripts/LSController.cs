using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSController : MonoBehaviour
{
    public float animSpeed;
    public Vector3 StartPos;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        offset = Random.Range(0, 10000);
        //StartPos = new Vector3(StartPos.x, StartPos.y + Random.Range(0, 0.25f), StartPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(StartPos.x, StartPos.y + Mathf.Sin((Time.time + offset) * animSpeed)/8, StartPos.z);
        //transform.position.y = new Vector3 ( Mathf.Sin(Time.time * 1));
    }
}
