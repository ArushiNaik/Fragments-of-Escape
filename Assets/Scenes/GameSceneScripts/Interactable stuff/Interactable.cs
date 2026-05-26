//using UnityEngine;
//using UnityEngine.InputSystem;

//public class Interactable : MonoBehaviour
//{
//    protected bool playerNearby;
//    private GameInputActions inputActions;

//    protected virtual void Awake()
//    {
//        inputActions = new GameInputActions();
//        inputActions.player.Enable();
//        inputActions.player.Interact.performed += ctx => OnInteractPressed();
//    }

//    protected virtual void OnDestroy()
//    {
//        inputActions.player.Disable();
//    }

//    private void OnInteractPressed()
//    {
//        if (!playerNearby) return;
//        Debug.Log("INTERACT TRIGGERED: " + gameObject.name);
//        Interact();
//    }

//    protected virtual void Interact()
//    {
//        GameMessageManager.instance?.ShowMessage("Interacted with " + gameObject.name);
//    }

//    protected virtual void OnTriggerEnter2D(Collider2D other)
//    {
//        if (!other.CompareTag("Player")) return;
//        playerNearby = true;
//        InteractionPromptUI.instance?.ShowPrompt();
//    }

//    protected virtual void OnTriggerExit2D(Collider2D other)
//    {
//        if (!other.CompareTag("Player")) return;
//        playerNearby = false;
//        InteractionPromptUI.instance?.HidePrompt();
//    }
//}
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }

    public virtual string GetPromptText()
    {
        return "Press E to interact";
    }
}