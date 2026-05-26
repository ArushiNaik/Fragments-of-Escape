//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PuzzleTable : MonoBehaviour
//{
//    public KeyPuzzleController puzzle;
//    private bool playerNear;
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
//        puzzle.OpenPuzzle();
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
//// public class PuzzleTable : MonoBehaviour
//// {
////     public KeyPuzzleController puzzle;
////     private bool playerNear;

////     void Update()
////     {
////         if (playerNear && Input.GetKeyDown(KeyCode.E))
////         {
////             puzzle.OpenPuzzle();
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
public class PuzzleTable : Interactable
{
    public KeyPuzzleController puzzle;

    public override void Interact()
    {
        if (puzzle != null)
            puzzle.OpenPuzzle();
    }

    public override string GetPromptText()
    {
        return "Press E to interact";
    }
}