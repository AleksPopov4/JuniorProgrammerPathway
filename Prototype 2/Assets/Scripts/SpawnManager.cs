using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 16.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float repeatRate = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, repeatRate); // Start spawning animals after 2 seconds, repeat every 1.5 seconds
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}