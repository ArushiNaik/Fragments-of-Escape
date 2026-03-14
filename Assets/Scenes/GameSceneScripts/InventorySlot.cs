using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public GameObject useButton;

    Sprite item;

    public void SetItem(Sprite newItem)
    {
        item = newItem;
        icon.sprite = item;
        icon.enabled = true;
    }

    public void UseItem()
    {
        if (item != null)
        {
            InventoryManager.instance.SelectItem(item);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
            useButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        useButton.SetActive(false);
    }
}