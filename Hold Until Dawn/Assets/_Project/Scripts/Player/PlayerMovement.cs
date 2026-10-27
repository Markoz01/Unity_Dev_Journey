using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;

    private PlayerControls controls;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    private Vector2 facing = Vector2.down;

    private void Start()
    {
        controls = GetComponent<InputReader>().Controls;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        Vector2 snapped = SnapToFour(moveInput);
        if (snapped != Vector2.zero)
        {
            facing = snapped;
        }

        animator.SetFloat("MoveX", snapped.x);
        animator.SetFloat("MoveY", snapped.y);
        animator.SetFloat("LastX", facing.x);
        animator.SetFloat("LastY", facing.y);
        animator.SetFloat("Speed", snapped == Vector2.zero ? 0f : 1f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    // 4-directional facing, horizontal wins on diagonals (and ties).
    private static Vector2 SnapToFour(Vector2 v)
    {
        if (v.sqrMagnitude < 0.01f) return Vector2.zero;
        if (Mathf.Abs(v.x) >= Mathf.Abs(v.y))
            return new Vector2(Mathf.Sign(v.x), 0f);
        return new Vector2(0f, Mathf.Sign(v.y));
    }
}
