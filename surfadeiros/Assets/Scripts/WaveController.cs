using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    bool isRunning = false;
    [SerializeField] GameObject waveObject;

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
        // INCREMENT POINTS
        if (other.GetComponent<PlayerManager>() && !isRunning) {
            isRunning = true;
            gameObject.transform.parent = other.transform;
            LeanTween.rotateX(waveObject, -90f, 2);
            LeanTween.moveLocalY(waveObject, 1.27f, 2);
            LeanTween.moveLocalZ(waveObject, waveObject.transform.localPosition.z + 25f,1f);
            StartCoroutine("closeWave");
        }
    }
    IEnumerator closeWave()
    {
        yield return new WaitForSecondsRealtime(2);
        //LeanTween.rotateX(waveObject, 0f, .5f);
        LeanTween.moveLocalY(waveObject, -4.29f, 1f);
        gameObject.transform.parent = null;
        //isRunning = false;
    }

}
