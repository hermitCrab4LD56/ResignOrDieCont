using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifeTime);  // 自动销毁
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        // 调用玩家的血量系统
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage();
        }

        // 播特效音效
        FXManager.Instance.PlayHitFeedback(collision.transform.position);

        Destroy(gameObject);
    }
}

}
