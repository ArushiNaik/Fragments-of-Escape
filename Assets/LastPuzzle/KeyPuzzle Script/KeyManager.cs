using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool hasFragment1;
    public bool hasFragment2;
    public bool hasFragment3;

    [Header("Final Key")]
    public GameObject finalKeyObject;
    public GameObject puzzlePanel;

    [Header("Inventory References")]
    public Sprite fragment1Sprite;
    public Sprite fragment2Sprite;
    public Sprite fragment3Sprite;

    public void SetFragment(int id)
    {
        if (id == 1) hasFragment1 = true;
        if (id == 2) hasFragment2 = true;
        if (id == 3) hasFragment3 = true;

        Debug.Log($"SET FRAGMENT {id} TRUE");
    }

    public void CompleteKey()
    {
        Debug.Log("YOU MADE THE KEY!");

        if (finalKeyObject != null)
            finalKeyObject.SetActive(true);

        RemoveFragmentsFromInventory();

        if (puzzlePanel != null)
            puzzlePanel.SetActive(false);
    }

    void RemoveFragmentsFromInventory()
    {
        if (InventoryManager.instance == null) return;

        if (fragment1Sprite != null && InventoryManager.instance.HasItem(fragment1Sprite))
            InventoryManager.instance.RemoveItem(fragment1Sprite);

        if (fragment2Sprite != null && InventoryManager.instance.HasItem(fragment2Sprite))
            InventoryManager.instance.RemoveItem(fragment2Sprite);

        if (fragment3Sprite != null && InventoryManager.instance.HasItem(fragment3Sprite))
            InventoryManager.instance.RemoveItem(fragment3Sprite);
    }
}