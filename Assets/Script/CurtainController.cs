using UnityEngine;

public class CurtainController : MonoBehaviour
{
    public float raiseSpeed = 500f;

    private RectTransform rectTransform;
    private bool raising = false;
    private float screenHeight;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        screenHeight = Screen.height;

        // 设置幕布高度为屏幕高度（向上遮满）
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, screenHeight);

        // 设置初始位置：幕布在屏幕正下方
        rectTransform.anchoredPosition = new Vector2(0, -screenHeight);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            raising = true;
        }

        if (raising)
        {
            // 将 anchoredPosition.y 向上移动
            rectTransform.anchoredPosition += new Vector2(0, raiseSpeed * Time.deltaTime);

            // 限制位置，不超过顶部
            if (rectTransform.anchoredPosition.y >= 0)
            {
                rectTransform.anchoredPosition = new Vector2(0, 0);
                raising = false;
            }
        }
    }
}

