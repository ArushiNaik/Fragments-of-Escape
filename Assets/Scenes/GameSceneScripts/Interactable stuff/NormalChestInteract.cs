//using UnityEngine;
//using UnityEngine.InputSystem;

//public class NormalChestInteract : MonoBehaviour
//{
//    bool playerNearby = false;
//    normalChest chestPuzzle;
//    private GameInputActions inputActions;

//    void Awake()
//    {
//        chestPuzzle = GetComponent<normalChest>();
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
//        if (chestPuzzle != null)
//            chestPuzzle.TryOpenChest();
//    }

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerNearby = true;
//            GameMessageManager.instance.ShowMessage("Press E to open chest");
//        }
//    }

//    void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//            playerNearby = false;
//    }
//}

//// using UnityEngine;

//// public class NormalChestInteract : MonoBehaviour
//// {
////     bool playerNearby = false;
////     normalChest chestPuzzle;

////     void Start()
////     {
////         chestPuzzle = GetComponent<normalChest>();
////     }

////     void Update()
////     {
////         if (playerNearby && Input.GetKeyDown(KeyCode.E))
////         {
////             if (chestPuzzle != null)
////                 chestPuzzle.TryOpenChest();
////         }
////     }

////     void OnTriggerEnter2D(Collider2D other)
////     {
////         if (other.CompareTag("Player"))
////         {
////             playerNearby = true;
////             GameMessageManager.instance.ShowMessage("Press E to open chest");
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
public class NormalChestInteract : Interactable
{
    private normalChest chestPuzzle;

    private void Awake()
    {
        chestPuzzle = GetComponent<normalChest>();
    }

    public override void Interact()
    {
        if (chestPuzzle != null)
            chestPuzzle.TryOpenChest();
    }
    public override string GetPromptText()
    {
        return "Press E to open chest";
    }}