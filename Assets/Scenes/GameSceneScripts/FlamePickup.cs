using UnityEngine;

public class FlamePickup : Interactable
{
    public Sprite itemSprite;

    public override void Interact()
    {
        InventoryManager.instance.AddItem(itemSprite);
        Destroy(gameObject);
    }
}