using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        GameMessageManager.instance.ShowMessage("Interacted with " + gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            InteractionPromptUI.instance.ShowPrompt();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            InteractionPromptUI.instance.HidePrompt();
        }
    }
}