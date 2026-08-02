using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public enum ActionState
    {
        Free,
        Attacking,
        Hit
    }

    public ActionState CurrentState { get; private set; } = ActionState.Free;

    public bool CanMove => CurrentState == ActionState.Free;

    public void SetState(ActionState newState)
    {
        CurrentState = newState;
    }
}
