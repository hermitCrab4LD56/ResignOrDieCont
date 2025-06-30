using UnityEngine;
using System.Collections;

public class CurtainObjectDrag : MonoBehaviour
{
    public float dragThreshold = 2f; // 超过多少单位后触发自动上拉
    public float autoRaiseSpeed = 5f;
    // public GameObject dialogueBox;
    // public MonoBehaviour[] scriptsToDisable;

    private Vector3 dragOffset;
    private bool isDragging = false;
    private bool autoRaising = false;
    private bool raised = false;

    private Camera mainCam;
    private float startY;

    void Start()
    {
        mainCam = Camera.main;
        startY = transform.position.y;
    }

    void OnMouseDown()
    {
        if (autoRaising || raised) return;

        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        dragOffset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging || autoRaising || raised) return;

        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(transform.position.x, mouseWorldPos.y + dragOffset.y, transform.position.z);

        // 限制幕布不能往下拖回去
        if (newPos.y >= startY)
            transform.position = newPos;
    }

    void OnMouseUp()
    {
        if (!isDragging || autoRaising || raised) return;

        float draggedDistance = transform.position.y - startY;

        if (draggedDistance >= dragThreshold)
        {
            StartCoroutine(AutoRaise());
        }

        isDragging = false;
    }

    IEnumerator AutoRaise()
    {
        autoRaising = true;

        // // 禁用控制器
        // foreach (var script in scriptsToDisable)
        // {
        //     script.enabled = false;
        // }

        // 自动往上滚动
        float targetY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        while (transform.position.y < targetY)
        {
            transform.position += Vector3.up * autoRaiseSpeed * Time.deltaTime;
            yield return null;
        }

        // if (dialogueBox != null)
        // {
        //     dialogueBox.SetActive(true);
        // }

        raised = true;
    }
}
