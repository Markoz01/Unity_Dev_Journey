
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private GameManager gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Detect collision with other objects
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.LoseLife();
        }

        if (other.gameObject.CompareTag("Food"))
        {
        gameManager.AddScore(1);
        Destroy(gameObject);
        Destroy(other.gameObject);
        }


        
    }

}
