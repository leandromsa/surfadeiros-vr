using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] GameObject modelsObject;
    int scoreValue = 5;

    // Start is called before the first frame update
    void Start()
    {
        if(modelsObject.transform.childCount > 0)
            modelsObject.transform.GetChild(UnityEngine.Random.Range(0, modelsObject.transform.childCount)).gameObject.SetActive(true);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x + UnityEngine.Random.Range(-3f, 3f), gameObject.transform.position.y, gameObject.transform.position.z + UnityEngine.Random.Range(-3f, 3f)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // INCREMENT POINTS
        if(other.GetComponent<PlayerManager>())
            other.GetComponent<PlayerManager>().IncrementScore(scoreValue);
        // DESATIVATE TRASH
        gameObject.SetActive(false);
        AkSoundEngine.PostEvent("PlayTrashCollect", gameObject);
    }
}
