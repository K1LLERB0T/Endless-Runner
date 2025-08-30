using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the spawning of randomly placed fences, PowerUps and coins in unique lanes of a chunk
/// </summary>
public class Chunk : MonoBehaviour
{
    // Fence, PowerUp and Coin prefab
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] GameObject coinPrefab;

    // Collectible spawn chances
    [SerializeField] float powerUpSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;

    // Space between coins
    [SerializeField] float coinSeparationLength = 2f;

    // Defining lane positions
    [SerializeField] float[] lanes = { -3f, 0f, 3f };

    LevelGenerator levelGenerator;
    ScoreManager scoreManager;

    // Create a list of available lanes
    List<int> availableLanes = new List<int> { 0, 1, 2 };

    // Spawn fences at the start of a chunk
    void Start()
    {
        SpawnFence();
        SpawnPowerUp();
        SpawnCoin();
    }

    public void Init(LevelGenerator levelGenerator, ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }

    // Spawn fences in random lanes without overlap
    void SpawnFence()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            // Break if no lanes are available
            if (availableLanes.Count <= 0)
                break;

            int selectedLane = SelectLane();

            // Calculate spawn position and instantiate fence
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    // Spawn PowerUp in a random lane
    void SpawnPowerUp()
    {
        // Chance and lane availability check for PowerUp spawn
        if (Random.value > powerUpSpawnChance || availableLanes.Count <= 0)
            return;

        int selectedLane = SelectLane();

        // Calculate spawn position and instantiate PowerUp
        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        PowerUp newPowerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<PowerUp>();
        newPowerUp.Init(levelGenerator);
    }

    // Spawn coins in a random lane with separation
    void SpawnCoin()
    {
        // Chance and lane availability check for Coin spawn
        if (Random.value > coinSpawnChance || availableLanes.Count <= 0)
            return;

        int selectedLane = SelectLane();

        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);

        float zPosOfChunk = transform.position.z + (coinSeparationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            // Calculate spawn position and instantiate Coin
            float spawnPositionZ = zPosOfChunk - (i * coinSeparationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
            newCoin.Init(scoreManager);
        }
    }

    // Select and remove a random lane from the available lanes and return the index of selected lane
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        // int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return randomLaneIndex;
    }
}
