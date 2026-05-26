using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class InteractableObject : Interactable
{
    [Header("Animation")]
    public Animator animator;
    public string interactTrigger = "Interact";
    private bool playerNearby;
    [Header("Door / Collision")]
    public Collider2D blockingCollider;
    public float disableDelay = 0f;

    [Header("Content")]
    public bool hasItem;
    public GameObject itemPrefab;

    public bool hasNote;
    [TextArea] public string noteText;

    public bool destroyAfterUse = false;

    private bool hasInteracted = false;

    public override void Interact()
    {
        if (hasInteracted) return;
        hasInteracted = true;

        StartCoroutine(HandleInteraction());
    }

    IEnumerator HandleInteraction()
    {
        if (animator != null)
            animator.SetTrigger(interactTrigger);
        if (blockingCollider != null)
            blockingCollider.enabled = false;

        if (hasItem && itemPrefab != null)
        {
            GameObject g = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }

        yield return null;
    }
    public void DisableCollider()
    {
        if (blockingCollider != null)
        {
            blockingCollider.enabled = false;
        }
    }
    private void Update()
    {
        if (playerNearby && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Press E to interact");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
