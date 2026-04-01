using UnityEngine;

public class InteractableObject : Interactable
{
    [Header("Animation")]
    public Animator animator;
    public string interactTrigger = "Interact";

    [Header("Content")]
    public bool hasItem;
    public GameObject itemPrefab;

    public bool hasNote;
    [TextArea] public string noteText;

    public bool destroyAfterUse = false;

    protected override void Interact()
    {
        // Prevent repeat spam
        if (hasInteracted) return;
        hasInteracted = true;

        // Play animation
        if (animator != null)
        {
            animator.SetTrigger(interactTrigger);
        }

        // Spawn item
        if (hasItem && itemPrefab != null)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }

        // Show note
        if (hasNote)
        {
            GameMessageManager.instance.ShowMessage(noteText);
        }

        // Empty fallback
        if (!hasItem && !hasNote)
        {
            GameMessageManager.instance.ShowMessage("It's empty.");
        }

        // Optional destroy (for pots)
        if (destroyAfterUse)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private bool hasInteracted = false;
}