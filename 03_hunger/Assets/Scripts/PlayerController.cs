using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    float horizontalInput;

    private float speed = 20.0f;

    private float xRange = 20.0f;

    [SerializeField] private GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Spawn food when the W key is pressed
        if(Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
        }

    }
}
