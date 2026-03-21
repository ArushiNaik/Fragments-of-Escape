using UnityEngine;

public class FragmentPickup : MonoBehaviour
{
    public Sprite itemIcon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager inv = FindAnyObjectByType<InventoryManager>();
            inv.AddItem(itemIcon);

            gameObject.SetActive(false);
        }
    }
}