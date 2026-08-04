using UnityEngine;

public class PlayerFatigue : MonoBehaviour
{
    [Header("Fatigue")]
    [SerializeField] private float maxFatigue = 100f;
    [SerializeField] private float decayDelay = 1f;
    [SerializeField] private float decayRate = 5f;

    public float CurrentFatigue { get; private set; }

    private PlayerStateController stateController;
    private float timeSinceLastAction;

    private void Start()
    {
        stateController = GetComponent<PlayerStateController>();
    }

    private void Update()
    {
        if (stateController.CurrentState != PlayerStateController.ActionState.Free)
        {
            timeSinceLastAction = 0f;
        }
        else
        {
            timeSinceLastAction += Time.deltaTime;
        }

        if (timeSinceLastAction >= decayDelay && CurrentFatigue > 0f)
        {
            DecreaseFatigue(decayRate * Time.deltaTime);
        }
    }

    public void IncreaseFatigue(float amount)
    {
        CurrentFatigue = Mathf.Clamp(CurrentFatigue + amount, 0f, maxFatigue);
    }

    private void DecreaseFatigue(float amount)
    {
        CurrentFatigue = Mathf.Clamp(CurrentFatigue - amount, 0f, maxFatigue);
    }
}
