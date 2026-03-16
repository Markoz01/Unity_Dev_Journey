using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    // Array of ball prefabs
    [SerializeField] GameObject[] ballPrefabs;

    // Spawn position limits
    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    // Spawn timing
    private float startDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        // Random spawn time
        float spawnTime = Random.Range(3,5);

        // Invoke SpawnRandomBall again after a random delay
        Invoke("SpawnRandomBall", spawnTime);

    }

}
