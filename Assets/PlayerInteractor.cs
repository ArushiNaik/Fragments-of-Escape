using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    private List<Interactable> nearbyInteractables = new List<Interactable>();
    private GameInputActions inputActions;

    private void Awake()
    {
        inputActions = new GameInputActions();
        inputActions.player.Enable();
        inputActions.player.Interact.performed += ctx => TryInteract();
    }

    private void OnDestroy()
    {
        inputActions.player.Interact.performed -= ctx => TryInteract();
        inputActions.player.Disable();
    }

    private void TryInteract()
    {
        Interactable closest = GetClosestInteractable();

        if (closest != null)
        {
            closest.Interact();
        }
    }

    private Interactable GetClosestInteractable()
    {
        if (nearbyInteractables.Count == 0)
            return null;

        Interactable closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Interactable interactable in nearbyInteractables)
        {
            if (interactable == null)
                continue;

            float distance = Vector2.Distance(
                transform.position,
                interactable.transform.position
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = interactable;
            }
        }

        return closest;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check on the object itself AND its parent
        Interactable interactable = other.GetComponent<Interactable>()
                                 ?? other.GetComponentInParent<Interactable>();

        if (interactable != null && !nearbyInteractables.Contains(interactable))
        {
            nearbyInteractables.Add(interactable);
            InteractionPromptUI.instance?.ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>()
                                 ?? other.GetComponentInParent<Interactable>();

        if (interactable != null)
        {
            nearbyInteractables.Remove(interactable);
            if (nearbyInteractables.Count == 0)
                InteractionPromptUI.instance?.HidePrompt();
        }
    }
}