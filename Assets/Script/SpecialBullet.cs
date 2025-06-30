using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 1f;
    private Vector2 direction;
    private bool isPlayerControlled = false;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Invoke(nameof(EnablePlayerControl), lifeTime); // 延迟启用玩家控制
    }

    void Update()
    {
        if (!isPlayerControlled)
        {
            // 发射阶段
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // 玩家控制阶段
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector2 moveDir = new Vector2(moveX, moveY).normalized;
            transform.Translate(moveDir * speed * Time.deltaTime);
        }
    }

    void EnablePlayerControl()
    {
        isPlayerControlled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayerControlled && collision.CompareTag("Player"))
        {
            // 只有在发射阶段才能伤害玩家
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage();
            }

            FXManager.Instance.PlayHitFeedback(collision.transform.position);
            Destroy(gameObject);
        }
    }
}
