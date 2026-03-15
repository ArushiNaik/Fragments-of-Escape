using UnityEngine;

public class WaterPotion : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite itemSprite;

    protected override void Interact()
    {
        InventoryManager.instance.AddItem(itemSprite);
        Destroy(gameObject);
    }
}
