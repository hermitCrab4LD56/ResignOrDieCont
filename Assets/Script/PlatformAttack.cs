using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformAttack : MonoBehaviour
{
    public float bounceForce = 5f;               // 平台撞击后被弹开的力
    public AudioClip hitClip;                    // 撞击音效（可选）
    //public GameObject hitEffectPrefab;           // 撞击特效（可选）

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Turret"))
        {
            // 播放音效
            if (hitClip != null)
                AudioSource.PlayClipAtPoint(hitClip, transform.position);

            // 播放特效
            // if (hitEffectPrefab != null)
            //     Instantiate(hitEffectPrefab, collision.transform.position, Quaternion.identity);

            // 敌人掉血
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage();
            }

            // 计算反弹方向
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 center = rb.worldCenterOfMass;
            Vector2 bounceDir = (center - contactPoint).normalized;

            // 添加反弹力
            rb.linearVelocity = bounceDir * bounceForce;
        }
    }
}