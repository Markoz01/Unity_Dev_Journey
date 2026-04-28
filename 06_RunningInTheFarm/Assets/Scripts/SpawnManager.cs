using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    void Start()
    {
        Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
    }

    void Update()
    {
        
    }
}
