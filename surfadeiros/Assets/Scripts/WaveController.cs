using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem[] particlesSystem = { };
    bool isRunning = false;
    [SerializeField] GameObject waveObject;


    private PlayerLocomotion _tempPlayerLocObj;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ParticleSystem ps in particlesSystem) {
            ps.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(waveObject.transform.rotation); 
    }

    private void OnTriggerEnter(Collider other)
    {
        // INCREMENT POINTS
        if (other.GetComponent<PlayerManager>() && !isRunning) {
            
            Debug.Log("Wave started");
            isRunning = true;

            foreach (ParticleSystem ps in particlesSystem)
            {
                ps.Play();
            }

            // SET THE PARENT
            gameObject.transform.parent = other.transform;
            gameObject.transform.localPosition = Vector3.zero;


            _tempPlayerLocObj = other.GetComponent<PlayerLocomotion>();
            _tempPlayerLocObj.maxBoardSpeed = _tempPlayerLocObj.maxBoardSpeed + 10f;

            LeanTween.rotate(waveObject,  new Vector3(0f, 0f, -140f), 4f);
            LeanTween.moveLocalY(waveObject, 1.5f, 1.5f);
            //LeanTween.moveLocalZ(waveObject, waveObject.transform.localPosition.z - 20f,5f);

            AkSoundEngine.PostEvent("StartWave", waveObject);

            StartCoroutine("closeWave");
        }
    }

    IEnumerator closeWave()
    {
        yield return new WaitForSecondsRealtime(6);
        Debug.Log("Wave closed");
        gameObject.transform.parent = null;
        LeanTween.moveLocalZ(waveObject, waveObject.transform.localPosition.z - 40f,2f);
        _tempPlayerLocObj.maxBoardSpeed = _tempPlayerLocObj.maxBoardSpeed - 10f;
        ///LeanTween.rotateX(waveObject, 0f, 2f);
        LeanTween.moveLocalY(waveObject, -4.29f, 3f);
        //isRunning = false;
        yield return new WaitForSecondsRealtime(3);
        AkSoundEngine.PostEvent("StopWaveCrash", waveObject);
        yield return new WaitForSecondsRealtime(3);
        AkSoundEngine.PostEvent("StopWaveCrash", waveObject);
        foreach (ParticleSystem ps in particlesSystem)
        {
            ps.Stop();
        }
    }

}
