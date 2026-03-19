using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public Sprite keySprite;
    public TMP_Text interactionText;

    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        if (InventoryManager.instance == null)
        {
            Debug.LogError("InventoryManager missing!");
            return;
        }

        InventoryManager.instance.AddItem(keySprite);
        Debug.Log("Key picked up");

        if (interactionText != null)
            interactionText.text = "";

        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Key Trigger Entered by: " + other.name);

        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Player near key");
            playerNear = true;

            if (interactionText != null)
                interactionText.text = "Press E to pick up key";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            playerNear = false;

            if (interactionText != null)
                interactionText.text = "";
        }
    }
}