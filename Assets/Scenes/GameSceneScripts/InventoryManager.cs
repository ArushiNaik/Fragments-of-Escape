//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryManager : MonoBehaviour
//{
//    public static InventoryManager instance;

//    public GameObject slotPrefab;
//    public Transform slotParent;
//    public Sprite selectedItem;

//    private List<Sprite> items = new List<Sprite>();

//    void Awake()
//    {
//        instance = this;
//    }

//    public void AddItem(Sprite itemSprite)
//    {
//        if (!items.Contains(itemSprite))
//        {
//            items.Add(itemSprite);

//            if (slotPrefab != null && slotParent != null)
//            {
//                GameObject slot = Instantiate(slotPrefab, slotParent);

//                Image icon = slot.transform.Find("ItemIcon").GetComponent<Image>();
//                icon.sprite = itemSprite;
//                icon.color = Color.white;
//            }

//            GameMessageManager.instance.ShowMessage("Item added: " + itemSprite.name);
//        }
//    }

//    public void SelectItem(Sprite item)
//    {
//        selectedItem = item;
//        GameMessageManager.instance.ShowMessage("Item used");
//    }

//    public bool HasItem(Sprite itemSprite)
//    {
//        return items.Contains(itemSprite);
//    }

//    public void RemoveItem(Sprite itemSprite)
//    {
//        if (items.Contains(itemSprite))
//        {
//            items.Remove(itemSprite);

//            foreach (Transform slot in slotParent)
//            {
//                Transform iconTransform = slot.Find("ItemIcon");

//                if (iconTransform == null)
//                    continue;

//                Image icon = iconTransform.GetComponent<Image>();

//                if (icon != null && icon.sprite == itemSprite)
//                {
//                    Destroy(slot.gameObject);
//                    break;
//                }
//            }
//        }
//    }
//}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [Header("UI")]
    public GameObject slotPrefab;
    public Transform slotParent;

    [Header("Selection")]
    public Sprite selectedItem;

    private List<Sprite> items = new List<Sprite>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void AddItem(Sprite itemSprite)
    {
        if (itemSprite == null)
        {
            Debug.LogError("AddItem: sprite is NULL");
            return;
        }

        if (items.Contains(itemSprite))
        {
            Debug.Log("Item already in inventory: " + itemSprite.name);
            return;
        }

        if (slotPrefab == null || slotParent == null)
        {
            Debug.LogError("AddItem: UI references missing");
            return;
        }

        items.Add(itemSprite);

        GameObject slot = Instantiate(slotPrefab, slotParent);

        if (!slot.TryGetComponent(out RectTransform _))
        {
            Debug.LogError("Slot prefab invalid UI object");
        }

        Transform iconTransform = slot.transform.Find("ItemIcon");

        if (iconTransform == null)
        {
            Debug.LogError("ItemIcon missing in slot prefab");
            return;
        }

        Image icon = iconTransform.GetComponent<Image>();

        if (icon == null)
        {
            Debug.LogError("ItemIcon has no Image component");
            return;
        }

        icon.sprite = itemSprite;
        icon.color = Color.white;

        Debug.Log("Item successfully added: " + itemSprite.name);
    }

    public void SelectItem(Sprite item)
    {
        selectedItem = item;

        if (GameMessageManager.instance != null)
            GameMessageManager.instance.ShowMessage("Item selected");
    }

    public bool HasItem(Sprite itemSprite)
    {
        return items.Contains(itemSprite);
    }

    public void RemoveItem(Sprite itemSprite)
    {
        if (itemSprite == null) return;
        if (!items.Contains(itemSprite)) return;

        items.Remove(itemSprite);

        foreach (Transform slot in slotParent)
        {
            if (slot == null) continue;

            Transform iconTransform = slot.Find("ItemIcon");
            if (iconTransform == null) continue;

            Image icon = iconTransform.GetComponent<Image>();

            if (icon != null && icon.sprite == itemSprite)
            {
                Destroy(slot.gameObject);
                break;
            }
        }

        Debug.Log("Removed item: " + itemSprite.name);
    }
}