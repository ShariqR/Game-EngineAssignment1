using System;
using System.Windows.Input;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Subject
{
    Rigidbody2D rb;
    [SerializeField] int health = 100; //Starting health
    [SerializeField] int maxHealth = 100;
    //[SerializeField] int ammo = 0;
    [SerializeField] int moveSpeed;
    [SerializeField] int dashMultiplier;
    [SerializeField] LayerMask groundLayer;  // For checking if grounded
    [SerializeField] Transform groundCheck;  // Position to check for ground
    [SerializeField] float groundCheckRadius = 0.2f; // Radius for ground check
    [SerializeField] int bulletSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip gunshot;
    public PlayerInputActions playerControls;
    
    Vector2 moveDirection = Vector2.zero;
    private InputAction movement;
    private InputAction jumpAction; // Add this for jump input
    private float jumpPower = 15f;
    private bool isGrounded;

    [SerializeField] private UI ui;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();

        if (ui != null)
        {
            AddObserver(ui);
        }
        else
        {
            Debug.LogWarning("UI is null");
        }
        
        
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
        Command dashCommand = new DashCommand(rb, moveDirection, (moveSpeed * dashMultiplier));
        Command fireCommand = new FireCommand(bullet, rb, bulletSpeed, moveDirection);
        CheckIfGrounded(); // Check if the player is on the ground

        if (Input.GetKeyDown(KeyCode.Q))
            dashCommand.Execute();
        else if (Input.GetKeyDown(KeyCode.E))
            dashCommand.Undo();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManager.Instance.PlaySFX(gunshot);
            fireCommand.Execute();
        }
            
    }

    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log("There's movement");
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            AudioManager.Instance.PlaySFX(jumpSound);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower); // Apply upward force for jump
            Debug.Log("Jumping");
        }
    }

    // Check if the player is grounded by using an overlap circle at the ground check position
    private void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void TakeDamage(int damage)
    {
        
        health -= damage;
        if (health < 0) health = 0;

        NotifyObservers(health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            Debug.Log("ouchie");
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead");
    }
}
