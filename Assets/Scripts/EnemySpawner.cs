using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; // A list of group of enemies to spawn this wave
        public int waveQuota; //Total number of enemies to spawn in this wave
        public float spawnInterval; //The interval at which to spawn enemies 
        public int spawnCount; //The Number of enemies already spawn in this wave 
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; // the number of enemies spawn in this wave
        public int spawnCount; // the number of this type already spawned enemies
        public GameObject enemyPrefab;
    }

    public List<Wave> waves; // List of all waves in game
    public int currentWaveCount; //The Index of the current wave, starts from 0

    [Header("Spawn Attributes")]
    float spawnTimer; //Timer use to determine when the next enemy spawn
    public float waveInterval; //The interval between each wave

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints; //A List of all the relative spawn points

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0) // Check if wave ended and the next should start
        {
            StartCoroutine(BeginNextWave());
        }
        
            spawnTimer += Time.deltaTime;

            // Check if it's time to spawn next enemies
            if (spawnTimer >= waves[currentWaveCount].spawnInterval)
            {
                spawnTimer = 0f;
                SpawnEnemies();
            }
        
    }

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if(currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void SpawnEnemies()
    {
        //check if the minimum numbers of enemies in the wave have been spawned
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota) { 
            //spawn each type of enemy until the quota is filled 
            foreach (var enemyGroups in waves[currentWaveCount].enemyGroups)
            {
                //check if the minimum numbe of enemies of this type have been spawned
                if (enemyGroups.spawnCount < enemyGroups.enemyCount)
                {

                    Instantiate(enemyGroups.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    

                    enemyGroups.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                }
            }
        }
    }


}
