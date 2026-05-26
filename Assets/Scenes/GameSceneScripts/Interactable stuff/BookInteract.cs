// using UnityEngine;
//using UnityEngine.InputSystem;

//public class BookInteract : MonoBehaviour
//{
//    public string bookContent;
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
//        BookUIManager.instance.OpenBook(bookContent);
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

//// public class BookInteract : MonoBehaviour
//// {
////     public string bookContent; // text inside the book

////     private bool playerNearby = false;

////     void Update()
////     {
////         if (playerNearby && Input.GetKeyDown(KeyCode.E))
////         {
////             BookUIManager.instance.OpenBook(bookContent);
////         }
////     }

////     void OnTriggerEnter2D(Collider2D other)
////     {
////         if (other.CompareTag("Player"))
////         {
////             playerNearby = true;
////         }
////     }

////     void OnTriggerExit2D(Collider2D other)
////     {
////         if (other.CompareTag("Player"))
////         {
////             playerNearby = false;
////         }
////     }
//// }
using UnityEngine;
public class BookInteract : Interactable
{
    [TextArea]
    public string bookContent;

    public override void Interact()
    {
        BookUIManager.instance.OpenBook(bookContent);
    }
    public override string GetPromptText()
    {
        return "Press E to read";
    }}