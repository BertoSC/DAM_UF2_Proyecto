using UnityEngine;
using TMPro;

public class ScoreUI: MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Para mostrar la puntuación en el juego

    void Update()
    {
        if (scoreText != null)
        {
            
            scoreText.text = ScoreManager.instance.GetScore().ToString();
        }
    }
}