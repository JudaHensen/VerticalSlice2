using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {

    private int score = 0;
    private int highScore = 0;

    public event Action<int> ScoreUpdate;
    public event Action<int> HighScoreUpdate;

    void Start()
    {
        // request the highschore
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        ScoreUpdate(score);
        HighScoreUpdate(highScore);
    }

    // add x amount to score
    public void AddScore(int value)
    {
        score += value;
        ScoreUpdate(score);

        // if the score is higher then the highscore, set highscore to score
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            HighScoreUpdate(highScore);
        }
    }

    // reset normal score
    public void ResetScore()
    {
        score = 0;
        ScoreUpdate(score);
    }

    // reset the highscore
    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", 0);
        HighScoreUpdate(highScore);
    }
}
