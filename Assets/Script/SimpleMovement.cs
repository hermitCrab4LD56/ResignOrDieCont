using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private float dirY = 0f;

    [SerializeField] private float moveSpeed = 7f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);  // ✅ 注意这里是 velocity，不是 linearVelocity


    }

}
