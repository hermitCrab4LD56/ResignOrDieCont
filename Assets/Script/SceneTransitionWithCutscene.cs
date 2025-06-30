using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionWithCutscene : MonoBehaviour
{
    public GameObject cutsceneImage;      // Assign the full-screen cutscene image
    public string nextSceneName; // Name of the scene to load
    public float cutsceneDuration = 0.5f;   // Duration to show the image

    private bool conditionMet = false;

    void Update()
    {
        // Example condition: press space or set your own logic
        if (!conditionMet && Input.GetKeyDown(KeyCode.Space))
        {
            conditionMet = true;
            StartCoroutine(PlayCutsceneAndSwitch());
        }
    }

    private System.Collections.IEnumerator PlayCutsceneAndSwitch()
    {
        cutsceneImage.SetActive(true); // Show cutscene
        yield return new WaitForSeconds(cutsceneDuration);
        SceneManager.LoadScene(nextSceneName);
    }
}
