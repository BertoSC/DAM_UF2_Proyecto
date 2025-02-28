using UnityEngine;
using System.Collections.Generic; // Necesario para usar listas

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Lista de prefabs de enemigos
    public float spawnRate = 2f; // Tiempo entre spawns
    public float spawnHeightMin = -2f; // Altura mínima
    public float spawnHeightMax = 3f; // Altura máxima

    private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnRate;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Count == 0) return; // Evita errores si la lista está vacía

        // Selecciona un enemigo aleatorio de la lista
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        GameObject enemyToSpawn = enemyPrefabs[randomIndex];

        // Posición de spawn en el lado derecho de la pantalla
        Vector3 spawnPos = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1.2f, 0, 0)).x, 
                                       Random.Range(spawnHeightMin, spawnHeightMax), 
                                       0);

        // Instanciar el enemigo seleccionado
        Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
    }
}
