using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioClip defaultMusic;    // 初始背景音乐
    [SerializeField] private AudioClip finalSceneMusic; // 终章/结局背景音乐
    [SerializeField] private string finalSceneName = "FinalScene"; // 触发切换的场景名

    private AudioSource audioSource;

    void Awake()
    {
        // 确保只有一个实例存在
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 切换场景时保留
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.clip = defaultMusic;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == finalSceneName)
        {
            // 停止原音乐并播放新音乐
            audioSource.Stop();
            audioSource.clip = finalSceneMusic;
            audioSource.Play();
        }
    }
}
