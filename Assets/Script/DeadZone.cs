using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
     public GameObject cutsceneImage;       // UI 图像
    public string nextSceneName;
    public float delay = 2f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Turret"))
        {
            triggered = true;
            StartCoroutine(ShowCutsceneAndLoad());
        }
    }

    private System.Collections.IEnumerator ShowCutsceneAndLoad()
    {
        yield return new WaitForSeconds(delay);
        if (cutsceneImage != null)
            cutsceneImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<DialogueTriggerByEvent>()?.TriggerOutro();
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(nextSceneName);
    }
}
