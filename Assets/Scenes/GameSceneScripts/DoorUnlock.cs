//using UnityEngine;
//using UnityEngine.InputSystem;
//using TMPro;

//public class DoorUnlock : MonoBehaviour
//{
//    public Sprite requiredKey;
//    public TMP_Text interactionText;
//    private bool playerNear = false;
//    private GameInputActions inputActions;

//    void Awake()
//    {
//        inputActions = new GameInputActions();
//        inputActions.player.Enable();
//        inputActions.player.Interact.performed += ctx => OnInteract();
//    }

//    void OnDestroy()
//    {
//        inputActions.player.Disable();
//    }

//    void OnInteract()
//    {
//        if (!playerNear) return;
//        TryOpen();
//    }

//    void TryOpen()
//    {
//        if (InventoryManager.instance.HasItem(requiredKey))
//        {
//            GameMessageManager.instance.ShowMessage("Door unlocked!");
//            InventoryManager.instance.RemoveItem(requiredKey);
//            gameObject.SetActive(false);
//        }
//        else
//        {
//            GameMessageManager.instance.ShowMessage("You need a key");
//        }
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.transform.root.CompareTag("Player"))
//        {
//            playerNear = true;
//            interactionText.text = "Press E to use key";
//        }
//    }

//    void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.transform.root.CompareTag("Player"))
//        {
//            playerNear = false;
//            interactionText.text = "";
//        }
//    }
//}



//// public class DoorUnlock : MonoBehaviour
//// {
////     public Sprite requiredKey;
////     public TMP_Text interactionText;

////     private bool playerNear = false;

////     void Update()
////     {
////         if (playerNear && Input.GetKeyDown(KeyCode.E))
////         {
////             TryOpen();
////         }
////     }

////     void TryOpen()
////     {
////         if (requiredKey == null)
////         {
////             Debug.LogError("No key assigned!");
////             return;
////         }

////         if (InventoryManager.instance.HasItem(requiredKey))
////         {
////             GameMessageManager.instance.ShowMessage("Door unlocked!");
////             InventoryManager.instance.RemoveItem(requiredKey);
////             gameObject.SetActive(false);
////         }
////         else
////         {
////             GameMessageManager.instance.ShowMessage("You need a key");
////         }
////     }

////     void OnTriggerEnter2D(Collider2D other)
////     {
////         if (other.transform.root.CompareTag("Player"))
////         {
////             playerNear = true;
////             interactionText.text = "Press E to use key";
////         }
////     }

////     void OnTriggerExit2D(Collider2D other)
////     {
////         if (other.transform.root.CompareTag("Player"))
////         {
////             playerNear = false;
////             interactionText.text = "";
////         }
////     }
//// }
///
using UnityEngine;
using TMPro;

public class DoorUnlock : Interactable
{
    public Sprite requiredKey;
    public TMP_Text interactionText;

    public override void Interact()
    {
        TryOpen();
    }
    private void TryOpen()
    {
        if (requiredKey == null)
        {
            Debug.LogError("No key assigned!");
            return;
        }

        if (InventoryManager.instance.HasItem(requiredKey))
        {
            GameMessageManager.instance?.ShowMessage("Door unlocked!");
            InventoryManager.instance.RemoveItem(requiredKey);
            gameObject.SetActive(false);
        }
        else
        {
            GameMessageManager.instance?.ShowMessage("You need a key");
        }
    }

    public override string GetPromptText()
    {
        return "Press E to use key";
    }
}