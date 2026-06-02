using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    private PlayerController playerControllerScript;
    private float left = -15f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {        
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(transform.position.x < left && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
