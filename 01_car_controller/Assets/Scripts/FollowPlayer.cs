using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    private Vector3 thirdPersonOffset = new Vector3(0, 5, -10);

    private Vector3 firstPersonOffset = new Vector3(0, 3.12f, -0.5f);

    private bool isThirdPerson = true;

    private Quaternion thirdPersonInitialRotation;

    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        thirdPersonInitialRotation = transform.rotation;
    }

    void Update()
    {
        //Toggle between first-person and third-person view
        if (Input.GetKeyDown(KeyCode.T))
        {
            isThirdPerson = !isThirdPerson;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //Get horizontal input for camera rotation
        horizontalInput = Input.GetAxis("Horizontal");

        //Follow the player's position
        if(isThirdPerson)
        {
            transform.position = player.transform.position + thirdPersonOffset;
            transform.rotation = thirdPersonInitialRotation;
        }else
        {
            transform.position = player.position + player.rotation * firstPersonOffset;
            transform .rotation = player.rotation;
        }
        
    }
}
