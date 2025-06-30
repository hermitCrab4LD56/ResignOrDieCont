using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int damagePerHit = 1;

    public int MaxHealth => maxHealth;
    public int CurrentHealth { get; private set; }

    [SerializeField] private GameObject healthBarPrefab;
    private GameObject healthBarInstance;

    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        CurrentHealth = maxHealth;
        anim = GetComponent<Animator>();

        if (healthBarPrefab != null)
        {
            healthBarInstance = Instantiate(
                healthBarPrefab,
                transform.position + Vector3.up * 1.5f,
                Quaternion.identity,
                transform
            );
        }
    }

    public void TakeDamage()
    {
        if (isDead) return; // 死了就不处理

        // ✅ 扣血
        CurrentHealth -= damagePerHit;

        // ✅ 血量下限为 0
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
            return;
        }

        // ✅ 播放受击动画
        if (anim != null)
        {
            anim.SetTrigger("Hit");
        }
    }

    private void Die()
    {
        isDead = true;

        // ✅ 播放死亡动画
        if (anim != null)
        {
            anim.SetTrigger("Dead");
        }

        // ✅ 销毁血条
        if (healthBarInstance != null)
        {
            //Destroy(healthBarInstance);
            Destroy(gameObject, 2f);
        }

        // ✅ 你可以选择直接隐藏角色、禁用脚本或延迟销毁
        // gameObject.SetActive(false);
        // Destroy(gameObject, 2f); // 延迟2秒后销毁
    }
}
