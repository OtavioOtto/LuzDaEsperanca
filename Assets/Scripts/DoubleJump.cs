using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private BaseMovement baseMovement;
    private GroundCheck groundCheck;
    public bool canDoubleJump;
    private float doubleJumpCooldown = 0.3f;
    private float verde0;

    void Start()
    {
        baseMovement = GetComponent<BaseMovement>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Update()
    {
        verde0 = Input.GetAxis("VERDE0");
        if (groundCheck.onGround)
        {
            canDoubleJump = true;
            doubleJumpCooldown = 0.3f;
        }

        if (verde0 > 0.0f)
        {
            if (groundCheck.onGround)
            {
                baseMovement.HandleJump(groundCheck);
            }
        }
        if (!groundCheck.onGround) {
            if (canDoubleJump)
            {
                canDoubleJump = false;
                StartCoroutine(HandleDoubleJump());
                canDoubleJump = true;
                if (verde0 > 0.0f && canDoubleJump && doubleJumpCooldown == 0)
                {

                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    rb.velocity = new Vector2(rb.velocity.x, baseMovement.jumpForce);
                    canDoubleJump = false;

                }
            }

        }
    }


    private IEnumerator HandleDoubleJump()
    {
        yield return new WaitForSeconds(doubleJumpCooldown);
        doubleJumpCooldown = 0;
    }

}
