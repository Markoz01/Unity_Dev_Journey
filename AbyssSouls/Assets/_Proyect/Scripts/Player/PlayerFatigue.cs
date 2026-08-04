using UnityEngine;

public class PlayerFatigue : MonoBehaviour
{
    [Header("Fatigue")]
    [SerializeField] private float maxFatigue = 100f;
    [SerializeField] private float decayDelay = 1f;
    [SerializeField] private float decayRate = 5f;

    [Header("Fatigue Tier Thresholds")]
    [SerializeField] private float tier1FatigueThreshold = 70f;
    [SerializeField] private float tier2FatigueThreshold = 90f;

    public float CurrentFatigue { get; private set; }
    public bool IsExhausted { get; private set; }
    public float Tier1Threshold => tier1FatigueThreshold;
    public float Tier2Threshold => tier2FatigueThreshold;

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
        UpdateExhaustionState();
    }

    private void DecreaseFatigue(float amount)
    {
        CurrentFatigue = Mathf.Clamp(CurrentFatigue - amount, 0f, maxFatigue);
        UpdateExhaustionState();
    }

    private void UpdateExhaustionState()
    {
        if (CurrentFatigue >= maxFatigue)
        {
            IsExhausted = true;
        }
        else if (CurrentFatigue < tier1FatigueThreshold)
        {
            IsExhausted = false;
        }
    }
}
