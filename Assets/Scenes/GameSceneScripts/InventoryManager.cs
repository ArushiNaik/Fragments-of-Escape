using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public GameObject slotPrefab;
    public Transform slotParent;
    public Sprite selectedItem;

    private List<Sprite> items = new List<Sprite>();

    void Awake()
    {
        instance = this;
    }

    public void AddItem(Sprite itemSprite)
    {
        if (!items.Contains(itemSprite))
        {
            items.Add(itemSprite);

            if (slotPrefab != null && slotParent != null)
            {
                GameObject slot = Instantiate(slotPrefab, slotParent);

                Image icon = slot.transform.Find("ItemIcon").GetComponent<Image>();
                icon.sprite = itemSprite;
                icon.color = Color.white;
            }

            GameMessageManager.instance.ShowMessage("Item added: " + itemSprite.name);
        }
    }

    public void SelectItem(Sprite item)
    {
        selectedItem = item;
        GameMessageManager.instance.ShowMessage("Item used");
    }

    public bool HasItem(Sprite itemSprite)
    {
        return items.Contains(itemSprite);
    }

    public void RemoveItem(Sprite itemSprite)
    {
        if (items.Contains(itemSprite))
        {
            items.Remove(itemSprite);

            foreach (Transform slot in slotParent)
            {
                Transform iconTransform = slot.Find("ItemIcon");

                if (iconTransform == null)
                    continue;

                Image icon = iconTransform.GetComponent<Image>();

                if (icon != null && icon.sprite == itemSprite)
                {
                    Destroy(slot.gameObject);
                    break;
                }
            }
        }
    }
}