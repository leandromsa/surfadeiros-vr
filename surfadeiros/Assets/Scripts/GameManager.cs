using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public PlayerLocomotion loco;
    [SerializeField]
    public Text infoLabel;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("PlayGame", gameObject);
        loco.isRunning = false;
        StartCoroutine("startIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startIn()
    {
        yield return new WaitForSecondsRealtime(2);
        infoLabel.text = "3";
        yield return new WaitForSecondsRealtime(1);
        infoLabel.text = "2";
        yield return new WaitForSecondsRealtime(1);
        infoLabel.text = "1";
        yield return new WaitForSecondsRealtime(1);
        infoLabel.text = "";
        loco.isRunning = true;
    }

}
