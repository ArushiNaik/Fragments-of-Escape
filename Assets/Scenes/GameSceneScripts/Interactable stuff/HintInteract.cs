
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class HintInteract : MonoBehaviour
//{
//    public string hintText;
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
//        Debug.Log(hintText);
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//            playerNear = true;
//    }

//    void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//            playerNear = false;
//    }
//}

//// public class HintInteract : MonoBehaviour
//// {
////     public string hintText;
////     bool playerNear = false;

////     void Update()
////     {
////         if (playerNear && Input.GetKeyDown(KeyCode.E))
////         {
////             Debug.Log(hintText);
////         }
////     }

////     void OnTriggerEnter2D(Collider2D other)
////     {
////         if (other.CompareTag("Player"))
////             playerNear = true;
////     }

////     void OnTriggerExit2D(Collider2D other)
////     {
////         if (other.CompareTag("Player"))
////             playerNear = false;
////     }
//// }
///

using UnityEngine;

public class HintInteract : Interactable
{
    [TextArea]
    public string hintText;
    public override void Interact()
    {
        Debug.Log(hintText);
        GameMessageManager.instance?.ShowMessage(hintText);
    }

    public override string GetPromptText()
    {
        return "Press E to inspect";
    }
}