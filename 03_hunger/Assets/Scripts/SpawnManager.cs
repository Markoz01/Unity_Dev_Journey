using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] animalPrefabs;

    [Header("Top Spawn")]
    [SerializeField] private float spawnTopRangeX = 20f;
    [SerializeField] private float spawnTopPosZ = 20f;

    [Header("Side Spawn")]
    [SerializeField] private float spawnSidesTopRangeZ = 16f;
    [SerializeField] private float spawnSidesBottomPosZ = -2f;
    [SerializeField] private float sideSpawnX = 22f;

    [Header("Spawn Timing")]
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnDelay = 1.5f;

 
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimals), startDelay, spawnDelay);
    }

    private void SpawnRandomAnimals()
    {
        // Generate random spawn positions for the top and sides
        Vector3 spawnTopPos = new Vector3(Random.Range(-spawnTopRangeX, spawnTopRangeX), 0f, spawnTopPosZ);
        Vector3 spawnLeftPos = new Vector3(-sideSpawnX, 0f, Random.Range(spawnSidesBottomPosZ, spawnSidesTopRangeZ));
        Vector3 spawnRightPos = new Vector3(sideSpawnX, 0f, Random.Range(spawnSidesBottomPosZ, spawnSidesTopRangeZ));

        // Spawn animals at the generated positions with appropriate rotations
        SpawnAnimal(spawnTopPos, Quaternion.Euler(0f, 180f, 0f));
        SpawnAnimal(spawnLeftPos, Quaternion.Euler(0f, 90f, 0f));
        SpawnAnimal(spawnRightPos, Quaternion.Euler(0f, 270f, 0f));
    }

    // Helper method to spawn an animal at a given position and rotation    
    private void SpawnAnimal(Vector3 position, Quaternion rotation)
    {
        int randomIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[randomIndex], position, rotation);
    }

}
