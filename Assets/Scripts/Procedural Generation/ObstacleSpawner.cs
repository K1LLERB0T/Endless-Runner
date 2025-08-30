using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Spawns random obstacles at regular intervals.
/// </summary>
public class ObstacleSpawner : MonoBehaviour
{
    // Obstacle configuration
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float obstacleSpawnTime = 1f;

    // The parent transform for spawning obstacles
    [SerializeField] Transform obstacleParent;

    // The width within which obstacles can spawn
    [SerializeField] float spawnWidth = 4f;

    // Starts a coroutine for the spawning obstacles. 
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    // Coroutine that spawns obstacles at regular intervals.
    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            // Chooses a random obstacle from the array
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Calculates a spawn position
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);

            // Waits for some time before spawning next obstacle.
            yield return new WaitForSeconds(obstacleSpawnTime);

            // Instantiates selected obstacle randomly 
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        }
    }
}
