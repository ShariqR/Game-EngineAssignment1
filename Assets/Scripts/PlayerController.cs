  using System;
using System.Windows.Input;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Subject
{
    public static PlayerController Instance { get; private set; }

    Rigidbody2D rb;
    [SerializeField] int health = 100; //Starting health
    [SerializeField] int maxHealth = 100;
    //[SerializeField] int ammo = 0;
    [SerializeField] int moveSpeed;
    [SerializeField] int dashMultiplier;
    [SerializeField] LayerMask groundLayer;  // For checking if grounded
    [SerializeField] Transform groundCheck;  // Position to check for ground
    [SerializeField] float groundCheckRadius = 0.2f; // Radius for ground check

    BulletFactory bulletFactory;
    [SerializeField] int bulletSpeed;
    
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip gunshot;
    public PlayerInputActions playerControls;
    Vector2 moveDirection = Vector2.zero;

    private InputAction movement;
    private InputAction jumpAction; // Add this for jump input
    private InputAction fireAction;
    private InputAction altFireAction;
    //private InputAction dashAction;
   // private InputAction reverseDashAction;

    private float jumpPower = 15f;
    private bool isGrounded;

    [SerializeField] private UI ui;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
        bulletFactory = FindObjectOfType<BulletFactory>();

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

        fireAction = playerControls.Player.Fire;
        fireAction.Enable();

        altFireAction = playerControls.Player.AltFire;
        altFireAction.Enable();

        movement.performed += Move;
        jumpAction.performed += Jump;
        fireAction.performed += Fire;
        altFireAction.performed += AltFire;

        /*dashAction = playerControls.Player.Dash;
        dashAction.Enable();

        reverseDashAction = playerControls.Player.ReverseDash;
        reverseDashAction.Enable();

        dashAction.performed += Dash;
        reverseDashAction.performed += ReverseDash;*/
    }

    private void OnDisable()
    {
        movement.Disable();
        jumpAction.Disable();
        fireAction.Disable();
        altFireAction.Disable();
        //dashAction.Disable();
        //reverseDashAction.Disable();
    }

    void Update()
    {
        Vector2 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, currentVelocity.y);
        moveDirection = movement.ReadValue<Vector2>().normalized;
        CheckIfGrounded(); // Check if the player is on the ground
        Command dashCommand = new DashCommand(rb, moveDirection, (moveSpeed * dashMultiplier));

        if (Input.GetKeyDown(KeyCode.Q))
            dashCommand.Execute();
        else if (Input.GetKeyDown(KeyCode.E))
            dashCommand.Undo();
    }


    void Fire(InputAction.CallbackContext context)
    {
        Command fireCommand = new FireCommand(bulletFactory, rb, bulletSpeed, moveDirection, BulletType.Normal);
        AudioManager.Instance.PlaySFX(gunshot);
        fireCommand.Execute();
    }

    void AltFire(InputAction.CallbackContext context)
    {
        Command fireCommand = new FireCommand(bulletFactory, rb, bulletSpeed, moveDirection, BulletType.Large);
        AudioManager.Instance.PlaySFX(gunshot);
        fireCommand.Execute();
    }

    /*void Dash(InputAction.CallbackContext context)
    {
        Command dashCommand = new DashCommand(rb, moveDirection, (moveSpeed * dashMultiplier));
        dashCommand.Execute();
    }

    void ReverseDash(InputAction.CallbackContext context)
    {
        Command dashCommand = new DashCommand(rb, moveDirection, (moveSpeed * dashMultiplier));
        dashCommand.Undo();
    } */

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
