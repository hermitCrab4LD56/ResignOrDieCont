using UnityEngine;
using UnityEngine.Video;

public class VideoOverlayController : MonoBehaviour
{
    public VideoPlayer videoPlayer;    // 播放器组件
    public GameObject videoPanel;      // 显示视频的 RawImage 容器

    void Start()
    {
        if (videoPanel != null)
            videoPanel.SetActive(true); // 确保一开始视频 UI 显示

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished; // 注册播放结束事件
            videoPlayer.Play(); // 开始播放
        }
        else
        {
            Debug.LogError("请在 Inspector 中指定 VideoPlayer");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        if (videoPanel != null)
        {
            videoPanel.SetActive(false); // 播放完后隐藏 RawImage 面板，露出下层背景
        }
    }
}
