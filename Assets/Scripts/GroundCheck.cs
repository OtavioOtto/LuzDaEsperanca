using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform groundCheck;

    public bool onGround;

    private void Update()
    {
        ChangeLocation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            onGround = true;
        else
            onGround = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            onGround = true;
        else
            onGround = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            onGround = false;
    }

    private void ChangeLocation() {

        groundCheck.position = new Vector2(player.position.x, player.position.y);

    }
}
