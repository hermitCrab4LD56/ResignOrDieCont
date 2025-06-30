using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager Instance;

    public GameObject hitEffectPrefab;
    public AudioClip hitSound;

    void Awake()
    {
        Instance = this;
    }

    public void PlayHitFeedback(Vector3 position)
    {
        if (hitSound != null)
            AudioSource.PlayClipAtPoint(hitSound, position);

        if (hitEffectPrefab != null)
            Instantiate(hitEffectPrefab, position, Quaternion.identity);
    }
}
