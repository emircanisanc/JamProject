using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb2d;
    bool isGrounded;
    float nextJumpTime;

    public float moveSpeed = 3f;
    public float jumpForce = 300f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        HandleJump();
        HandleHorizontalMovement();
    }

    private void HandleHorizontalMovement()
    {
        var x = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(x * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = movement;
        HandleSpriteFlip(movement);
    }

    private void HandleSpriteFlip(Vector2 movement)
    {
        if (movement.x > 0)
            spriteRenderer.flipX = false;
        else if (movement.x < 0)
            spriteRenderer.flipX = true;
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(groundCheckTransform.position, Vector3.down, 0.3f, groundLayer);
    }

    private void HandleJump()
    {
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump") && Time.time >= nextJumpTime)
            {
                nextJumpTime = Time.time + 1f;
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
    }

}
