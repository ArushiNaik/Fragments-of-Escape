using UnityEngine;
using UnityEngine.UI;

public class LockWheel : MonoBehaviour
{
    public RectTransform content;
    public Image background;

    public float cellHeight = 80f;
    public float smoothTime = 0.12f;

    public Color normalColor = new Color(1f, 1f, 1f, 0.3f);
    public Color selectedColor = new Color(1f, 0.8f, 0f, 1f);

    private int currentValue = 0;
    private float targetY;
    private float velocity = 0f;
    private bool isMoving = false;

    private float totalHeight;

    void Start()
    {
        totalHeight = 10 * cellHeight; // one full 0–9 cycle

        SetInstant(0);
        SetSelected(false);
    }

    void Update()
    {
        if (!isMoving) return;

        Vector2 pos = content.anchoredPosition;

        pos.y = Mathf.SmoothDamp(pos.y, targetY, ref velocity, smoothTime);

        // TRUE infinite wrap
        if (pos.y >= totalHeight)
            pos.y -= totalHeight;

        if (pos.y < 0)
            pos.y += totalHeight;

        content.anchoredPosition = pos;

        if (Mathf.Abs(pos.y - targetY) < 0.1f)
        {
            content.anchoredPosition = new Vector2(0, targetY);
            isMoving = false;

            UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }
    }

    public void ScrollUp()
    {
        currentValue = (currentValue + 1) % 10;
        Move();
    }

    public void ScrollDown()
    {
        currentValue--;
        if (currentValue < 0) currentValue = 9;
        Move();
    }

    void Move()
    {
        targetY = currentValue * cellHeight;
        isMoving = true;
    }

    public int GetValue()
    {
        return currentValue;
    }

    public void SetInstant(int value)
    {
        currentValue = value;
        targetY = value * cellHeight;

        content.anchoredPosition = new Vector2(0, targetY);

        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }

    public void SetSelected(bool isSelected)
    {
        if (background != null)
            background.color = isSelected ? selectedColor : normalColor;
    }
}