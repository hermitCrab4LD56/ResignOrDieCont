using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BattleSceneManager : MonoBehaviour
{
    [Header("Health Targets")]
    public Health playerHealth;   // 玩家Health脚本
    public Health enemyHealth;    // 敌人Health脚本

    [Header("Cutscene UI")]
    public GameObject successCutscene;
    public GameObject defeatCutscene;

    [Header("Scene Settings")]
    public string successSceneName;
    public string defeatSceneName;
    public float cutsceneDuration = 2f;

    private bool resultTriggered = false;

    // void Start()
    // {
    //     Screen.SetResolution(1920, 1080, false);
    // }


    void Update()
    {
        if (resultTriggered) return;

        if (enemyHealth.CurrentHealth <= 0)
        {
            resultTriggered = true;
            StartCoroutine(HandleResult(true));
        }
        else if (playerHealth.CurrentHealth <= 0)
        {
            resultTriggered = true;
            StartCoroutine(HandleResult(false));
        }
    }

    IEnumerator HandleResult(bool playerWon)
    {
        if (playerWon)
        {
            successCutscene.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            FindObjectOfType<DialogueTriggerByEvent>()?.TriggerOutro();
            yield return new WaitForSeconds(cutsceneDuration);
            SceneManager.LoadScene(successSceneName);
        }
        else
        {
            defeatCutscene.SetActive(true);
            yield return new WaitForSeconds(cutsceneDuration);
            SceneManager.LoadScene(defeatSceneName);
        }
    }
}
