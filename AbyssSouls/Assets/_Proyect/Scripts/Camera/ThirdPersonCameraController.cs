using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Orbit Settings")]
    [SerializeField] private float distance = 4f;
    [SerializeField] private float mouseSensitivity = 0.15f;
    [SerializeField] private float minPitch = -20f;
    [SerializeField] private float maxPitch = 60f;

    [Header("Collision Settings")]
    [SerializeField] private float collisionRadius = 0.5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float collisionSmoothSpeed = 10f;

    private PlayerControls controls;
    private float yaw;
    private float pitch;
    private float currentDistance;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        Vector3 startAngles = transform.eulerAngles;
        yaw = startAngles.y;
        pitch = startAngles.x;
        currentDistance = distance;
    }

    private void LateUpdate()
    {
        Vector2 look = controls.Player.Look.ReadValue<Vector2>();

        yaw += look.x * mouseSensitivity;
        pitch -= look.y * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 direction = rotation * -Vector3.forward;

        float desiredDistance = GetCameraDistance(direction);
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, collisionSmoothSpeed * Time.deltaTime);

        transform.position = direction * currentDistance + target.position;
        transform.rotation = rotation;
    }

    private float GetCameraDistance(Vector3 direction)
    {
        Vector3 origin = target.position;
        float radius = collisionRadius;
        RaycastHit hitInfo;
        float maxDistance = distance;

        if (Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask))
        {
            return hitInfo.distance;
        }

        return distance;
    }
}
