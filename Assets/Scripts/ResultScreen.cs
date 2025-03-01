using UnityEngine;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        int finalScore = ScoreManager.instance.GetScore();
        scoreText.text = finalScore.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = highScore.ToString();
    }
}