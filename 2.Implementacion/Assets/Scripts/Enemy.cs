using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;    // Animator del enemigo (debe estar asignado en el prefab)
    public float deathDelay = 0.5f;  // Tiempo en segundos para destruir el objeto después de la animación
    private bool isDead = false; // Para evitar múltiples llamadas a Die()

    // Método que se llama cuando el enemigo muere
    public void Die()
    {
        if (isDead)
            return;

        isDead = true;

        // Activa la animación de muerte
        if(animator != null)
        {
            animator.SetTrigger("Death"); // Asegúrate de tener un Trigger llamado "Death" en el Animator
        }
        else
        {
            Debug.LogWarning("No se encontró Animator en el enemigo.");
        }

        // Deshabilita colisiones para evitar interacciones adicionales
        Collider2D col = GetComponent<Collider2D>();
        if(col != null)
        {
            col.enabled = false;
        }

        // (Opcional) Detén cualquier movimiento o comportamiento adicional aquí

        // Destruye el objeto después del retraso
        Destroy(gameObject, deathDelay);
    }
}