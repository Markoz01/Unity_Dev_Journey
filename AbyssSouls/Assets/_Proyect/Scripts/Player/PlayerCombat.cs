using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackDuration = 1.0f;
    [SerializeField] private float attackFatigueCost = 10f;

    [Header("Fatigue Penalty Tiers")]
    [SerializeField] private float tier1SpeedMultiplier = 0.7f;
    [SerializeField] private float tier2SpeedMultiplier = 0.5f;

    private PlayerControls controls;
    private PlayerStateController stateController;
    private PlayerFatigue playerFatigue;
    private float attackTimer;

    private void Start()
    {
        controls = GetComponent<InputReader>().Controls;
        playerFatigue = GetComponent<PlayerFatigue>();
        stateController = GetComponent<PlayerStateController>();
    }

    private void Update()
    {
        if (controls.Player.Attack.WasPressedThisFrame() && stateController.CurrentState == PlayerStateController.ActionState.Free && !playerFatigue.IsExhausted)
        {
            stateController.SetState(PlayerStateController.ActionState.Attacking);
            playerFatigue.IncreaseFatigue(attackFatigueCost);
            attackTimer = 0f;
        }

        if (stateController.CurrentState == PlayerStateController.ActionState.Attacking)
        {
            attackTimer += Time.deltaTime * GetFatigueSpeedMultiplier();
            if (attackTimer >= attackDuration)
            {
                stateController.SetState(PlayerStateController.ActionState.Free);
            }
        }
    }

    private float GetFatigueSpeedMultiplier()
    {
        if (playerFatigue.CurrentFatigue >= playerFatigue.Tier2Threshold)
        {
            return tier2SpeedMultiplier;
        }

        if (playerFatigue.CurrentFatigue >= playerFatigue.Tier1Threshold)
        {
            Debug.Log("Tier 1 fatigue penalty applied.");
            return tier1SpeedMultiplier;
        }

        return 1f;
    }
}
