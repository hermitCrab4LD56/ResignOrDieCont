using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class ClickableImage : MonoBehaviour
{
    public AudioClip clickSound;            // 点击音效
    public string targetSceneName;          // 要跳转的场景名

    private AudioSource audioSource;

    void Start()
    {
        // 创建临时音源
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnMouseDown()
    {
        // 播放音效
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);

        // 跳转场景（延迟执行以等音效播完，可选）
        Invoke(nameof(LoadTargetScene), 0.3f); // 可根据音效长度调整时间
    }

    void LoadTargetScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
            SceneManager.LoadScene(targetSceneName);
    }
}