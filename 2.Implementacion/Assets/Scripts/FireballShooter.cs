using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab; 
    public Transform firePoint;     
    public float fireballSpeed = 10f; 
    public float shootInterval = 0.1f;  

    void Start()
    {
        InvokeRepeating("ShootFireball", shootInterval, shootInterval);
    }

    void ShootFireball()
    {
        if (this == null) return;  // Si el enemigo ha sido destruido, no dispares
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }

    public void StopShooting()
    {
        CancelInvoke("ShootFireball"); // Detiene el InvokeRepeating
    }

    private void OnDestroy()
    {
        StopShooting(); // Asegura que se detenga al morir
    }
}