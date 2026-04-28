using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
