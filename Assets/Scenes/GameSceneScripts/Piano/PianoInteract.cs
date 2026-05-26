//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PianoInteract : MonoBehaviour
//{
//    public PianoPuzzle pianoPuzzle;

//    private bool playerNearby = false;
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
//        if (!playerNearby) return;
//        pianoPuzzle.OpenPiano();
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//            playerNearby = true;
//    }

//    void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//            playerNearby = false;
//    }
//}
//// public class PianoInteract : MonoBehaviour
//// {
////     public PianoPuzzle pianoPuzzle;

////     private bool playerNear = false;

////     void Update()
////     {
////         if (!playerNear) return;

////         if (InteractionPromptUI.instance != null)
////             InteractionPromptUI.instance.ShowPrompt();

////         if (Input.GetKeyDown(KeyCode.E))
////         {
////             if (pianoPuzzle != null)
////             {
////                 Debug.Log("OPEN");
////                 pianoPuzzle.OpenPiano();
////             }
////         }
////     }

////     void OnTriggerEnter2D(Collider2D other)
////     {
////         if (other.transform.root.CompareTag("Player"))
////         {
////             playerNear = true;

////             if (InteractionPromptUI.instance != null)
////                 InteractionPromptUI.instance.ShowPrompt();
////         }
////     }

////     void OnTriggerExit2D(Collider2D other)
////     {
////         if (other.transform.root.CompareTag("Player"))
////         {
////             playerNear = false;

////             if (InteractionPromptUI.instance != null)
////                 InteractionPromptUI.instance.HidePrompt();
////         }
////     }
//// }
///

using UnityEngine;

public class PianoInteract : Interactable
{
    public PianoPuzzle pianoPuzzle;

    public override void Interact()
    {
        if (pianoPuzzle != null)
            pianoPuzzle.OpenPiano();
    }

    public override string GetPromptText()
    {
        return "Press E to play piano";
    }
}