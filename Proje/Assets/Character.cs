using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 3f;
    [HideInInspector] public Vector2 direction = Vector2.right;
    [HideInInspector] public Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 movemenet = new Vector2(moveSpeed * direction.x, rb2d.velocity.y);
        rb2d.velocity = movemenet;
    }

    public void StartMove(Vector2 direction)
    {
        this.direction = direction;
        enabled = true;
    }
}
