using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Slider slider;
    private Health targetHealth;

    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        targetHealth = GetComponentInParent<Health>();

        if (targetHealth != null)
        {
            slider.maxValue = targetHealth.MaxHealth;
            slider.value = targetHealth.CurrentHealth;
        }
    }

    void Update()
    {
        if (targetHealth != null)
        {
            slider.value = targetHealth.CurrentHealth;

            if (targetHealth.CurrentHealth <= 0)
                Destroy(gameObject); // 血条一起消失
        }
    }
}
