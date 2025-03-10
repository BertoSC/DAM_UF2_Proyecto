using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 6f; // Velocidad de la bola de fuego
    public float lifetime = 3f;
    public AudioClip firesound; 

    void Start()
    {
        AudioSource.PlayClipAtPoint(firesound, transform.position, 1f); // Reproduce el sonido de la bola de fuego
        // Destruye la bola de fuego después de un tiempo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mueve la bola de fuego hacia la derecha (o la dirección que elijas)
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shuriken")) // Si golpea al jugador
        {
          
            // Destruye la bola de fuego al colisionar
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground")) // Si golpea el suelo
        {
            // Destruye la bola de fuego al tocar el suelo
            Destroy(gameObject);
        }
    }
}