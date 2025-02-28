using UnityEngine;
using System.Collections.Generic; // Necesario para usar List

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs; // Lista de prefabs de obstáculos
    public float minSpawnRate = 1f;  // Tiempo mínimo entre spawns
    public float maxSpawnRate = 3f;  // Tiempo máximo entre spawns
    public Transform spawnPoint; 

    void Start()
    {
        // Llama a SpawnObstacle con un retraso inicial y luego repite con un spawnRate aleatorio
        Invoke("SpawnObstacle", Random.Range(minSpawnRate, maxSpawnRate));
        
    }

    void SpawnObstacle()
    {
        // Selecciona un prefab aleatorio de la lista
        GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        // Instancia el obstáculo en la posición del spawnPoint
        Instantiate(randomObstacle, spawnPoint.position, Quaternion.identity);

        // Programa el próximo spawn con un nuevo spawnRate aleatorio
        float nextSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        Invoke("SpawnObstacle", nextSpawnRate);
    }
}