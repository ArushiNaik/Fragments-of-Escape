using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private Vector2 startPosition;

    public bool locked = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (locked) return;

        startPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (locked) return;

        rectTransform.anchoredPosition +=
            eventData.delta / canvas.scaleFactor;
    }

    public void ReturnToStart()
    {
        rectTransform.anchoredPosition = startPosition;
    }
}