using UnityEngine;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField] private int maxFeed = 1;
    private int currentFeed;

    public int CurrentFeed => currentFeed;
    public int MaxFeed => maxFeed;
    public bool IsFullyFed => currentFeed >= maxFeed;

    private void Awake()
    {
        if (maxFeed < 1)
        {
            maxFeed = 1;
        }

        currentFeed = 0;
    }

    public void Feed()
    {
        if (IsFullyFed)
            return;

        currentFeed++;
    }
}