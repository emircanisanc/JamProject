using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator animator;

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

        if (rb2d.velocity.y < 0)
            animator.SetBool("Jump", false);
    }

    private void HandleHorizontalMovement()
    {
        var x = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(x * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = movement;
        animator.SetBool("isRunning", x != 0);
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
        animator.SetBool("isGrounded", isGrounded);
    }

    private void HandleJump()
    {
        if (isGrounded)
        {
            if (Input.GetButtonDown("Vertical") && Time.time >= nextJumpTime)
            {
                animator.SetBool("Jump", true);
                nextJumpTime = Time.time + 1f;
                rb2d.AddForce(Vector2.up * jumpForce);
            }
        }
    }

}
