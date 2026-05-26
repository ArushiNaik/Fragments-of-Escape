using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CageAnim : MonoBehaviour
{
    [SerializeField] private Animator cageAnimator;
    [SerializeField] private FriendController friendController;
    [SerializeField] private Collider2D cageWalls;
    [SerializeField] private Collider2D frontWall;
    [SerializeField] private Sprite fullKeySprite;
    [SerializeField] private float openAnimDuration = 0.8f;

    private bool hasBeenOpened = false;
    private bool playerInRange = false;
    private GameInputActions inputActions;

    void Awake()
    {
        inputActions = new GameInputActions();
        inputActions.player.Enable();
        inputActions.player.Interact.performed += ctx => OnInteract();
    }

    void OnDestroy()
    {
        inputActions.player.Interact.performed -= ctx => OnInteract();
        inputActions.player.Disable();
    }

    void OnInteract()
    {
        if (!playerInRange || hasBeenOpened) return;
        TryOpenCage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasBeenOpened || !other.CompareTag("Player")) return;

        playerInRange = true;

        if (InventoryManager.instance != null && InventoryManager.instance.HasItem(fullKeySprite))
            GameMessageManager.instance.ShowPersistentMessage("Press E to open the cage");
        else
            GameMessageManager.instance.ShowPersistentMessage("You need the final key");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInRange = false;
        GameMessageManager.instance?.ClearMessage();
    }

    private void TryOpenCage()
    {
        if (!InventoryManager.instance.HasItem(fullKeySprite))
        {
            GameMessageManager.instance.ShowMessage("You need the final key!");
            return;
        }

        hasBeenOpened = true;
        GameState.CageOpened = true;

        playerInRange = false;
        GameMessageManager.instance.ClearMessage();

        StartCoroutine(OpenSequence());
    }

    private IEnumerator OpenSequence()
    {
        GameMessageManager.instance.ShowMessage("Opening cage...");

        if (cageAnimator != null)
            cageAnimator.SetTrigger("isOpen");

        yield return new WaitForSeconds(openAnimDuration);

        if (frontWall != null) frontWall.enabled = false;
        if (cageWalls != null) cageWalls.enabled = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        if (friendController != null)
            friendController.SetFree();
    }
}