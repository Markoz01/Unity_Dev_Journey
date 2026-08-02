using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float attackDuration = 1.0f;

    private PlayerControls controls;
    private PlayerStateController stateController;
    private float attackTimer;

    private void Start()
    {
        controls = GetComponent<InputReader>().Controls;
        stateController = GetComponent<PlayerStateController>();
    }

    private void Update()
    {
        if (controls.Player.Attack.WasPressedThisFrame() && stateController.CurrentState == PlayerStateController.ActionState.Free)
        {
            stateController.SetState(PlayerStateController.ActionState.Attacking);
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
