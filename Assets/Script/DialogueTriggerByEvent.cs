using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerByEvent : MonoBehaviour
{
    public DialogueManager dialogueManager;  // 引用对话管理器
    public DialogueData introDialogue;       // 场景加载后触发
    public DialogueData outroDialogue;       // 通关后触发

    private bool outroTriggered = false;

    void Start()
    {
        // 2秒后触发开场对话
        if (introDialogue != null && dialogueManager != null)
        {
            Invoke("TriggerIntro", 0.05f);
        }
    }

    void TriggerIntro()
    {
        dialogueManager.StartDialogue(introDialogue);
    }

    public void TriggerOutro()
    {
        if (outroDialogue != null && dialogueManager != null && !outroTriggered)
        {
            dialogueManager.StartDialogue(outroDialogue);
            outroTriggered = true; // 防止重复触发
        }
    }
}
