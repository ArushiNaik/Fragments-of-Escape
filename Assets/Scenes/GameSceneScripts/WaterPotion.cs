//using UnityEngine;

//public class WaterPotion : Interactable
//{
//    public Sprite itemSprite;

//    public override void Interact()
//    {
//        InventoryManager.instance.AddItem(itemSprite);
//        Destroy(gameObject);
//    }
//}

using UnityEngine;

public class WaterPotion : Interactable
{
    public Sprite itemSprite;

    private void Start()
    {
        // Verify this component is found correctly
        Debug.Log("WaterPotion ready on: " + gameObject.name);
    }

    public override void Interact()
    {
        Debug.Log("WaterPotion Interact called!");

        if (InventoryManager.instance != null && itemSprite != null)
            InventoryManager.instance.AddItem(itemSprite);

        Destroy(gameObject);
    }
}