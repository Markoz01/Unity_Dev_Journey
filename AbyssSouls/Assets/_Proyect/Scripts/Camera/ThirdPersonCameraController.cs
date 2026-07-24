using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    
    [Header("Target")]
    [SerializeField] Transform target;

    [Header("Orbit Settings")]
    [SerializeField] float distance = 4f;
    [SerializeField] float mouseSensitivity = 0.15f;
    [SerializeField] float minPitch = -20f;
    [SerializeField] float maxPitch = 60f;

    private PlayerControls controls;
    private float yaw;
    private float pitch;


    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        Vector3 startAngles = transform.eulerAngles;
        yaw = startAngles.y;
        pitch = startAngles.x;
    }

    void LateUpdate()
    {
        Vector2 look = controls.Player.Look.ReadValue<Vector2>();

        yaw += look.x * mouseSensitivity;
        pitch -= look.y * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        transform.position = (rotation * -Vector3.forward) * distance + target.position;
        transform.rotation = rotation;
    }

}
