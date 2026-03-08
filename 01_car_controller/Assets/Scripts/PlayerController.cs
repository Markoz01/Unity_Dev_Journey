using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Private Variables
    [SerializeField] private float speed = 10.0f; 
    [SerializeField] private float turnSpeed = 25.0f; 

    //Input Variables
    [SerializeField] string horizontalAxis;
    [SerializeField] string verticalAxis;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //Get the user's input
        horizontalInput = Input.GetAxis(horizontalAxis);
        forwardInput = Input.GetAxis(verticalAxis);

        //Move the vehicle forward
        transform.Translate(Vector3.forward * speed * forwardInput * Time.deltaTime);
        
        //Turn the vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
