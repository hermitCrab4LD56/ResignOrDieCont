using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    public int SceneNumber;        // 场景编号
    public List<string> sentences;  // 对话句子列表
}