﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour{

    [SerializeField]
    private string message;

    private Text text;
    private ScoreSystem scoreSystem;

    void Awake()
    {
        text = GetComponent<Text>();
        scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();

        scoreSystem.HighScoreUpdate += UpdateDisplay;
    }

    private void UpdateDisplay(int value)
    {
        text.text = message + value.ToString();
    }
}


