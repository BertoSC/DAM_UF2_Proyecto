using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 10f; // Velocidad del shuriken
    public float lifetime = 3f; // Tiempo antes de que desaparezca

    public AudioClip impactSound;

    void Start()
    {
        Destroy(gameObject, lifetime); // Eliminar el shuriken después de un tiempo
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Mover el shuriken
    }

    
  void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Enemy"))
    {
        Enemy enemyScript = other.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.Die();
            AudioSource.PlayClipAtPoint(impactSound, transform.position, 2f);
            
            ScoreManager.instance.AddScore(25);
        }
        else
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject); // Destruye el shuriken
    }

    if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Deadly"))
    {
        Destroy(gameObject);
    }
}

    
}
