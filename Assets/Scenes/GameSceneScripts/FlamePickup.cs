using UnityEngine;

public class FlamePickup : Interactable
{
    public Sprite itemSprite;

    protected override void Interact()
    {
        InventoryManager.instance.AddItem(itemSprite);
        Destroy(gameObject);
    }
}