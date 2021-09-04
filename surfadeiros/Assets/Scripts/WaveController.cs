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

            gameObject.transform.parent = other.transform;
            _tempPlayerLocObj = other.GetComponent<PlayerLocomotion>();
            _tempPlayerLocObj.maxBoardSpeed = _tempPlayerLocObj.maxBoardSpeed + 10f;

            LeanTween.rotateX(waveObject, -90f, 2f);
            LeanTween.moveLocalY(waveObject, 1.57f, 2f);
            LeanTween.moveLocalZ(waveObject, waveObject.transform.localPosition.z + 23f,1f);

            AkSoundEngine.PostEvent("PlayWaveCrash", waveObject);

            StartCoroutine("closeWave");
        }
    }

    IEnumerator closeWave()
    {
        Debug.Log("Wave closed");
        yield return new WaitForSecondsRealtime(3);
        gameObject.transform.parent = null;
        _tempPlayerLocObj.maxBoardSpeed = _tempPlayerLocObj.maxBoardSpeed - 10f;
        ///LeanTween.rotateX(waveObject, 0f, 2f);
        LeanTween.moveLocalY(waveObject, -4.29f, 1f);
        //isRunning = false;

        yield return new WaitForSecondsRealtime(1);
        foreach (ParticleSystem ps in particlesSystem)
        {
            ps.Stop();
        }
    }

}
