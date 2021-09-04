using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{

    private int score = 0;

    [SerializeField]
    private Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore(int addScore) {
        this.score += addScore;
        scoreLabel.text = score.ToString();
    }

    public int GetScore() {
        return this.score;
    }
}
