using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleForwardMover : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the vehicle forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
