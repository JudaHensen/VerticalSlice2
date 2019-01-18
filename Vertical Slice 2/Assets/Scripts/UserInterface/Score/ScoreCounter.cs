using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    private Text scoreText; //Creates Text

    private int score; //Creates the score

    public int Score //Get % Sets score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    void Start () {

        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + 0;
        score = 0;
	}


}
