using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    public AudioClip stompClip;         // 踩死音效
    public GameObject stompEffectPrefab; // 蹦出音符的 prefab

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Turret"))
    {
        // 播放音效
        AudioSource.PlayClipAtPoint(stompClip, transform.position);

        // 生成特效（音符）
        if (stompEffectPrefab != null)
            Instantiate(stompEffectPrefab, other.transform.position + Vector3.up * 0.5f, Quaternion.identity);

        // 炮塔扣血
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage();
        }

        // 玩家反弹跳一下
        Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 8f);
    }
}

}
