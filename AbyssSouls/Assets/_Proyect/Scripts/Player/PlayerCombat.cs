using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackDuration = 1.0f;
    [SerializeField] private float attackFatigueCost = 10f;

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
        if (controls.Player.Attack.WasPressedThisFrame() && stateController.CurrentState == PlayerStateController.ActionState.Free)
        {
            stateController.SetState(PlayerStateController.ActionState.Attacking);
            playerFatigue.IncreaseFatigue(attackFatigueCost);
            attackTimer = 0f;
        }

        if (stateController.CurrentState == PlayerStateController.ActionState.Attacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                stateController.SetState(PlayerStateController.ActionState.Free);
            }
        }
    }
}
