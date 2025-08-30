using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the procedural generation of an infinite level by creating, moving and destroying level chunks.
/// </summary>
public class LevelGenerator : MonoBehaviour
{
    // Unity Editor controllable
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;

    // Created this array initially to manage chunks, but replaced it with a list now which manages all enabled chunks.
    // GameObject[] chunks = new GameObject[12];
    List<GameObject> chunks = new List<GameObject>();

    // Starts the level by creating initial set of chunks
    void Start()
    {
        SpawnStartingChunk();
    }

    // Called every frame to manage chunk movement
    void Update()
    {
        MoveChunks();
    }

    // Spawns the initial chunks to build the level
    void SpawnStartingChunk()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    // Spawns a new chunk at the end of the current level and adds it to the list.
    private void SpawnChunk()
    {
        // Gets the Z-position for the new chunk.
        float spawnPositionZ = CalculateSpawnPositionZ();

        // Intantiate the chunk and adds it to the list,
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    // Calculates the spawn position for the new chunk, places it after the destruction of a chunk.
    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        // if no chunk exists, spawn at generator position.
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }

        // else spawn at the end of the last chunk.
        else
        {
            // Old way of calculating spawn position, when the array was used.
            // spawnPositionZ = transform.position.z + (chunkLength * i);
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    // Moves all chunks towards the player and managed the offscreen chunks.
    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];

            // Moves the chunk
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            // If chunk is offscreen, remove it and generate a new one.
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
