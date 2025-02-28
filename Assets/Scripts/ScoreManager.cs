using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton para acceder desde otros scripts
    public TextMeshProUGUI scoreText;
    private int score = 0; 
    private float timer = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            AddScore(100); // Suma 100 puntos por segundo
            timer = 0f;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString(); 
    }
}