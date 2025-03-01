using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton para acceder desde otros scripts
    
    private int score = 0; 
    private float timer = 0f;

     void Start()
    {
        score = 0;
       
    }

    void Awake() {
        if(instance == null){
            instance = this;    
            DontDestroyOnLoad(gameObject); // Evitar que el objeto se destruya al cambiar de escena
        } else {
            // Si ya existe una instancia, destruimos el nuevo GameManager para mantener la singularidad
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            AddScore(5); 
            timer = 0f;
        }
    }

     public void AddScore(int amount)
    {
        score += amount;
       
    }

    public void ResetScore()
    {
        score = 0;
      
    }

    public int GetScore()
{
    return score;
}

}