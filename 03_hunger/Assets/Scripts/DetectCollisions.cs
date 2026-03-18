
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Detect collision with other objects
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

}
