using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour{

    public Text score;
    public Text highScore;

    void Start()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void RollDice()
    {
        int number = Random.Range(1, 101);
        score.text = "Score: " + number.ToString();

        if(number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = "HighScore: " + number.ToString();
        }
        
    }


}


