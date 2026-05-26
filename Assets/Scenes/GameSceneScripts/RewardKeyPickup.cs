using UnityEngine;

public class RewardKeyPickup : MonoBehaviour
{
    public Sprite itemIcon;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager inv = FindAnyObjectByType<InventoryManager>();
            inv.AddItem(itemIcon);
            
            if (InteractionPromptUI.instance != null)
                InteractionPromptUI.instance.HidePrompt();

            gameObject.SetActive(false);
        }
    }
}