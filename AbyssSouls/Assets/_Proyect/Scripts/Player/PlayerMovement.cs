using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;
    private CharacterController controller;

    [SerializeField] Transform cameraTransform;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 720f;
    [SerializeField] float gravity = -20f;
    private float verticalVelocity;


    private void Awake()
    {
        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 direction = camForward * input.y + camRight * input.x;

        if(direction.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if(controller.isGrounded)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        
        Vector3 totalMove = direction * moveSpeed + Vector3.up * verticalVelocity;
        controller.Move(totalMove * Time.deltaTime);

    }

}