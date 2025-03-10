using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 5f; // Velocidad del movimiento del fondo
    private float width; // Ancho del fondo
    private Vector3 startPosition;

    void Start()
    {
        // Obtén el ancho del fondo (tamaño en X del sprite)
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position; // Guarda la posición inicial
    }

    void Update()
    {
        // Mueve el fondo hacia la izquierda
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Cuando el fondo haya pasado completamente de la pantalla, reseteamos su posición
        if (transform.position.x <= startPosition.x - width)
        {
            transform.position = startPosition; // Devuelve el fondo a la posición original
        }
    }
}