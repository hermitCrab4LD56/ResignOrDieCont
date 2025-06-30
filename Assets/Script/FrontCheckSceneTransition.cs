using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrontCheckSceneTransition : MonoBehaviour
{
    [Header("Target Detection")]
    // public GameObject target;                  // Target to check if in front
    public float frontDotThreshold = 0.9f;     // 1 = directly in front

    [Header("Cutscene Settings")]
    public GameObject cutsceneImage;           // Fullscreen UI image
    public string nextSceneName;               // Scene to load
    public float cutsceneDuration = 2f;      // Time before scene change

    private bool conditionMet = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Char"))
        {
            

            //可以立即触发UI&音效
            StartCoroutine(PlayCutsceneAndSwitch());

        }
            

           
    }


    private System.Collections.IEnumerator PlayCutsceneAndSwitch()
    {
        yield return new WaitForSeconds(0.5f);
        // Debug.Log("成功");
        if (cutsceneImage != null)
            cutsceneImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<DialogueTriggerByEvent>()?.TriggerOutro();
        yield return new WaitForSeconds(cutsceneDuration);
        SceneManager.LoadScene(nextSceneName);
    }
}
