using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
    }

}
