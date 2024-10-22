using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField] int moveSpeed;
    float speedMultiplier;

    bool isBtnPressed;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movementSpeed = moveSpeed * speedMultiplier;

        rb.linearVelocity = new Vector2(movementSpeed, rb.linearVelocityY);
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            isBtnPressed = true;
        }
        else if (value.canceled)
        {
            isBtnPressed = false;
        }
    }
}
