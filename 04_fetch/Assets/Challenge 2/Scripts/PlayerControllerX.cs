using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField]public GameObject dogPrefab;

    private float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawnTime)
        {
            // Set the next spawn time to be 1 second from now
            nextSpawnTime = Time.time + 1.0f;
            
            // Instantiate the dog prefab at the player's position and rotation
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

        }
    }


}
