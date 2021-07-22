using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    int scoreValue = 5;

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
        if(playerManager)
            playerManager.IncrementScore(scoreValue);
        // DESATIVATE TRASH
        gameObject.SetActive(false);
    }
}
