using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;
    private float sideBound = 25f;

    private void Update()
    {
        if (IsOutOfBounds())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOutOfBounds()
    {
        return transform.position.z > topBound ||
               transform.position.z < lowerBound ||
               transform.position.x > sideBound ||
               transform.position.x < -sideBound;
    }
}