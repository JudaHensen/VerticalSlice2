using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    [SerializeField]
    private string message;

    private Text text;
    private ScoreSystem scoreSystem;

    void Awake () {
        text = GetComponent<Text>();
        scoreSystem = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<ScoreSystem>();

        scoreSystem.ScoreUpdate += UpdateDisplay;
    }

    private void UpdateDisplay(int value)
    {
        text.text = message + value.ToString();
    }

}
