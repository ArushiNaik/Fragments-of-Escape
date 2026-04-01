using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    bool playerNearby = false;
    ChestPuzzle chestPuzzle;

    void Start()
    {
        chestPuzzle = GetComponent<ChestPuzzle>();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (chestPuzzle != null)
                chestPuzzle.TryOpenChest();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            GameMessageManager.instance.ShowMessage("Press E to open chest");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}