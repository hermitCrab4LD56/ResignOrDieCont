using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOp : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    public string targetTag = "Enemy";            // 要碰撞的对象 Tag
    public string defeatSceneName = "Final"; // 要切换的场景名
    public float cutsceneDuration = 2f;            // 延迟切场景的时间
    [SerializeField] private float moveSpeed = 7f;

    private float dirX = 0f;
    private float dirY = 0f;
    private bool triggered = false;                // 防止重复触发

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag(targetTag))
        {
            triggered = true;

            Debug.Log("OK");

            // 播放 Outro 对话
            FindObjectOfType<DialogueTriggerByEvent>()?.TriggerOutro();

            // 开始延迟加载场景的协程
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(cutsceneDuration);
        SceneManager.LoadScene(defeatSceneName);
    }
}
