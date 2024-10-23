using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int moveSpeed;
    [SerializeField] LayerMask groundLayer;  // For checking if grounded
    [SerializeField] Transform groundCheck;  // Position to check for ground
    [SerializeField] float groundCheckRadius = 0.2f; // Radius for ground check
    public PlayerInputActions playerControls;

    Vector2 moveDirection = Vector2.zero;
    private InputAction movement;
    private InputAction jumpAction; // Add this for jump input
    private float jumpPower = 15f;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerControls.Player.Move;
        movement.Enable();

        jumpAction = playerControls.Player.Jump;
        jumpAction.Enable();

        movement.performed += Move;
        jumpAction.performed += Jump;
    }

    private void OnDisable()
    {
        movement.Disable();
        jumpAction.Disable();
    }

    void Update()
    {
        Vector2 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, currentVelocity.y);

        moveDirection = movement.ReadValue<Vector2>();

        CheckIfGrounded(); // Check if the player is on the ground
    }

    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log("There's movement");
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower); // Apply upward force for jump
            Debug.Log("Jumping");
        }
    }

    // Check if the player is grounded by using an overlap circle at the ground check position
    private void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
