using UnityEngine;

public class FeatherPickup : Interactable
{
    public Sprite itemSprite;

    public override void Interact()
    {
        InventoryManager.instance.AddItem(itemSprite);
        Destroy(gameObject);
    }
}