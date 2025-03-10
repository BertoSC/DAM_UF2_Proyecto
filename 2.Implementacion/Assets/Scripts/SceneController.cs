using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour

   
{
     public static int score = 0; 
    public static int highScore = 0;
   

    void Awake()
{
    DontDestroyOnLoad(gameObject); 
    if (FindObjectsOfType<SceneController>().Length > 1)
    {
        Destroy(gameObject); // Evita duplicados entre escenas
    }
}
    void Update()
    {
        // Para pasar de Pantalla de Título e Instrucciones al siguiente nivel
        if (Input.anyKeyDown && SceneManager.GetActiveScene().buildIndex == 0) // Título
        {
            SceneManager.LoadScene(1); // Instrucciones
        }

        if (Input.anyKeyDown && SceneManager.GetActiveScene().buildIndex == 1) // Instrucciones
        {
            SceneManager.LoadScene(2); // Juego
        }

        // Si estamos en la pantalla de resultados...
        if (SceneManager.GetActiveScene().buildIndex == 3)

        {
             
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Reiniciamos la puntuación
                ScoreManager.instance.ResetScore();
                SceneManager.LoadScene(2); // Volver a jugar
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit(); // Salir del juego
                Debug.Log("Saliendo del juego..."); // Solo se ve en el editor
            }
        }
    }

    public static void GameOver()    {     

        SceneManager.LoadScene(3); 
    }
}