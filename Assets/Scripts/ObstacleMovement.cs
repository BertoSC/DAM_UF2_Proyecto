using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Mueve el obstáculo hacia la izquierda (eje X)
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el obstáculo sale de la pantalla por la izquierda, lo destruimos
        if (transform.position.x < -10) 
        {
            Destroy(gameObject);
        }
    }
}
