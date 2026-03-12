using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float horizontalInput;

    [SerializeField] private float speed = 10.0f;

    [SerializeField] private float xRange = 10.0f;

    [SerializeField] private GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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


        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
        }

    }
}
