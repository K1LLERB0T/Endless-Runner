using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the spawning of randomly placed fences in unique lanes of a chunk
/// </summary> <summary>
public class Chunk : MonoBehaviour
{
    // Fence prefab
    [SerializeField] GameObject fencePrefab;

    // Defining lane positions
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    // Spawn fences at the start of a chunk
    void Start()
    {
        SpawnFence();
    }

    // Spawns fences in random lanes without overlap
    void SpawnFence()
    {
        // Create a list of available lanes
        List<int> availableLanes = new List<int> { 0, 1, 2 };
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            // Break if no lanes are available
            if (availableLanes.Count <= 0)
                break;

            // Select a random lane from the available lanes
            int randomLaneIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);

            // Calculate spawn position and instantiate fence
            Vector3 spawnPosition = new Vector3(lanes[randomLaneIndex], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }
}
