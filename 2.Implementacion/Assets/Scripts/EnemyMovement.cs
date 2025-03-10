using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del enemigo

    void Update()
    {
        // Mueve al enemigo hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -10) 
        {
            Destroy(gameObject);
        }
    }


        // Destruir cuando salga de la pantalla
        /*if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, 0, 0)).x)
        {
            Destroy(gameObject);
        }*/
    }
