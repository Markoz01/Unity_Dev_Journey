using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 720f;

    [Header("Gravity & Jump")]
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float groundedVelocity = -2f;
    [SerializeField] private float jumpHeight = 2f;

    private const float MinMoveThreshold = 0.0001f;

    private PlayerControls controls;
    private CharacterController controller;
    private PlayerStateController stateController;
    private float verticalVelocity;

    private void Start()
    {
        controls = GetComponent<InputReader>().Controls;
        controller = GetComponent<CharacterController>();
        stateController = GetComponent<PlayerStateController>();
    }

    private void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 direction = camForward * moveInput.y + camRight * moveInput.x;

        if (stateController.CanMove)
        {
            HandleRotation(direction);
            HandleGravityAndJump();
            HandleMove(direction);
        }
    }

    private void HandleRotation(Vector3 direction)
    {
        if (direction.sqrMagnitude > MinMoveThreshold)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleGravityAndJump()
    {
        if (controller.isGrounded)
        {
            if (controls.Player.Jump.WasPressedThisFrame())
            {
                verticalVelocity = Mathf.Sqrt(-2f * gravity * jumpHeight);
            }
            else
            {
                verticalVelocity = groundedVelocity;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }

    private void HandleMove(Vector3 direction)
    {
        Vector3 totalMove = direction * moveSpeed + Vector3.up * verticalVelocity;
        controller.Move(totalMove * Time.deltaTime);
    }
}
