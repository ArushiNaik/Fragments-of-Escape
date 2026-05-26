using UnityEngine;
using UnityEngine.EventSystems;

public class PieceSnap : MonoBehaviour, IEndDragHandler
{
    public PuzzleSlot targetSlot;

    private RectTransform rectTransform;

    private DraggablePiece draggablePiece;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        draggablePiece = GetComponent<DraggablePiece>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggablePiece.locked)
            return;

        float distance = Vector2.Distance(
            rectTransform.position,
            targetSlot.transform.position
        );

        // Smaller distance = more precise placement
        if (distance < 25f)
        {
            // PERFECT alignment
            rectTransform.anchoredPosition =
                targetSlot.GetComponent<RectTransform>().anchoredPosition;

            draggablePiece.locked = true;

            targetSlot.PlacePiece(gameObject);
        }
        else
        {
            draggablePiece.ReturnToStart();
        }
    }
    private System.Collections.IEnumerator SnapToSlot()
    {
        Vector3 startPos = rectTransform.position;
        Vector3 endPos = targetSlot.transform.position;

        float t = 0f;
        float duration = 0.15f; // control speed here

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            rectTransform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        rectTransform.position = endPos;

        draggablePiece.locked = true;
        targetSlot.PlacePiece(gameObject);
    }
}