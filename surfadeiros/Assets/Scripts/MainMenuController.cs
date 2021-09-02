using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("PlayMainMenu", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        SceneManager.LoadScene("SampleScene");
        AkSoundEngine.PostEvent("StopMainMenu", gameObject);
    }

    public void endGame() {
        Application.Quit();
        AkSoundEngine.PostEvent("StopMainMenu", gameObject);

    }
}
