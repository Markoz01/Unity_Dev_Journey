
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private GameManager gameManager;
    private AnimalHunger animalHunger;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animalHunger = GetComponentInParent<AnimalHunger>();
    }

    // Detect collision with other objects
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.LoseLife();
        }else if (other.gameObject.CompareTag("Food"))
        {
            if (animalHunger != null)
            {
                animalHunger.Feed();
                
                if (animalHunger.IsFullyFed)
                {
                    gameManager.AddScore(1);
                    Destroy(transform.root.gameObject);
                }
            }
        
        Destroy(other.gameObject);
        }


        
    }

}
