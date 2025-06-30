using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float lifeTime = 1f;
    public float minForce = 4f;
    public float maxForce = 7f;
    public float torque = 180f;

    void Start()
    {
        Destroy(gameObject, lifeTime);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 控制方向：主要朝上，有左右轻微偏移
            Vector2 dir = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;

            // 控制力度：随机弹力
            float force = Random.Range(minForce, maxForce);
            rb.AddForce(dir * force, ForceMode2D.Impulse);

            // 控制旋转：左右旋转都可能
            float randomTorque = Random.Range(-torque, torque);
            rb.AddTorque(randomTorque, ForceMode2D.Impulse);
        }
    }
}
