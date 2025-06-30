using UnityEngine;
using UnityEngine.Video;

public class IntroVideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;     // 视频播放器组件
    public GameObject videoUI;          // 视频显示部分（RawImage、Panel、Canvas 等）
    public GameObject mainMenuUI;       // 菜单UI部分（按钮、背景等）

    void Start()
    {
        mainMenuUI.SetActive(false); // 隐藏菜单
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // 隐藏视频部分 UI
        if (videoUI != null)
            videoUI.SetActive(false);

        // 显示主菜单部分
        mainMenuUI.SetActive(true);
    }
}