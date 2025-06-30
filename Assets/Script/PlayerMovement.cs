using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;  // ✅ 添加动画组件引用

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();  // ✅ 获取 Animator
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);  // ✅ 注意这里是 velocity，不是 linearVelocity

        // ✅ 控制左右翻转
        if (dirX > 0) sprite.flipX = false;
        else if (dirX < 0) sprite.flipX = true;

        // ✅ 播放跳跃
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetBool("isJumping", true); // 跳起来
        }

        // ✅ 设置动画参数
        anim.SetBool("isRunning", dirX != 0);
        anim.SetBool("isJumping", !IsGrounded());  // 跳跃状态检测
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
