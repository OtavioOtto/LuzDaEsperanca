using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] public bool facingRight;

    [Header("Raycast Settings")]
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;


    [Header("Status Flags")]
    [SerializeField] public bool isGrounded;
    [SerializeField] private bool isSprinting;
    private float x0, verde0, preto0;
    public bool IsMoving { get; private set; }

    private Rigidbody2D rb;
    private GroundCheck groundCheck;

    void Start()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x0 = Input.GetAxis("HORIZONTAL0");
        verde0 = Input.GetAxis("VERDE0");
        preto0 = Input.GetAxis("PRETO0");
        CheckGroundStatus(groundCheck);
        HandleMovement();
        HandleJump(groundCheck);
        Flip();
    }

    private void CheckGroundStatus(GroundCheck check)
    {

            if (check.onGround && preto0 > 0.0f)
                isSprinting = true;

            else
                isSprinting = false;


    }

    public void HandleMovement()
    {

        if (x0 > 0.0f || x0 < 0.0f)
        {
            float moveInput = Input.GetAxis("HORIZONTAL0");
            float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

            rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
            IsMoving = moveInput != 0;
        }
    }
    private void Flip() {

        if (facingRight && Input.GetAxis("HORIZONTAL0") > 0f || !facingRight && Input.GetAxis("HORIZONTAL0") < 0f) {

            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        
        }
    
    }

    public void HandleJump(GroundCheck check)
    {
            if (check.onGround && verde0 > 0.0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }

}
