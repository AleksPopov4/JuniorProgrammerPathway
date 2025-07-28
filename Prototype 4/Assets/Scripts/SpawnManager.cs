using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f; // Range within which enemies can spawn

    public GameObject powerupPrefab;
    public GameObject enemyPrefab;
    public int enemyCount; // Total number of enemies in the game
    public int waveNumber = 1; // Current wave number

    private void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Spawn a powerup at the start
    }

    private void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length; // Count the number of active enemies
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber); // Spawn a new wave of enemies if none are left
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPosition;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}