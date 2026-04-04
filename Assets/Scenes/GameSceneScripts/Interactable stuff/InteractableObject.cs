using System.Collections;
using UnityEngine;

public class InteractableObject : Interactable
{
    [Header("Animation")]
    public Animator animator;
    public string interactTrigger = "Interact";

    [Header("Door / Collision")]
    public Collider2D blockingCollider;   // solid collider (NOT trigger)
    public float disableDelay = 0f;       // use 0 if using animation event

    [Header("Content")]
    public bool hasItem;
    public GameObject itemPrefab;

    public bool hasNote;
    [TextArea] public string noteText;

    public bool destroyAfterUse = false;

    private bool hasInteracted = false;

    protected override void Interact()
    {
        if (hasInteracted) return;
        hasInteracted = true;

        StartCoroutine(HandleInteraction());
    }

    IEnumerator HandleInteraction()
    {
        // Play animation
        if (animator != null)
        {
            animator.SetTrigger(interactTrigger);
        }

        // Disable collider (door opening)
        if (blockingCollider != null)
        {
            if (disableDelay > 0)
            {
                yield return new WaitForSeconds(disableDelay);
                blockingCollider.enabled = false;
            }
            // If delay = 0 → use Animation Event instead
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

        // Destroy (pots)
        if (destroyAfterUse)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    // 🔥 BEST METHOD (called from Animation Event)
    public void DisableCollider()
    {
        if (blockingCollider != null)
        {
            blockingCollider.enabled = false;
        }
    }
}