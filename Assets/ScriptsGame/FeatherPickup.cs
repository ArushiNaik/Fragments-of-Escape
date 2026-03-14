using UnityEngine;

public class FeatherPickup : Interactable
{
    public Sprite itemSprite;

    protected override void Interact()
    {
        InventoryManager.instance.AddItem(itemSprite);
        Destroy(gameObject);
    }
}