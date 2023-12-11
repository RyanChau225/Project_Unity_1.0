using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // List of enemy prefabs to spawn
    public List<Transform> relativeSpawnPoints; // List of relative spawn points around the player
    public float initialSpawnInterval = 2f; // Initial interval at which enemies are spawned
    public float spawnRateIncreaseInterval = 5f; // Time interval (in seconds) after which spawn rate increases
    public float speedIncreasePercent = 0.25f; // Speed increase percentage

    private Transform player;
    private float spawnTimer;
    private float speedMultiplier = 1f;
    private float timeSinceLastIncrease;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // Find the player in the scene
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        timeSinceLastIncrease += Time.deltaTime;

        if (spawnTimer >= initialSpawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }

        if (timeSinceLastIncrease >= spawnRateIncreaseInterval)
        {
            timeSinceLastIncrease = 0f;
            speedMultiplier += speedIncreasePercent; // Increase enemy speed
            initialSpawnInterval *= 0.95f; // Increase spawn rate by reducing interval
        }
    }

    void SpawnEnemy()
    {
        if (relativeSpawnPoints.Count > 0 && enemyPrefabs.Count > 0)
        {
            Transform spawnPoint = relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)];
            Vector3 spawnPosition = player.position + spawnPoint.localPosition;
            GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            GameObject enemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

            if (enemyMovement != null)
            {
                enemyMovement.SetSpeedMultiplier(speedMultiplier);
            }
        }
    }
}
