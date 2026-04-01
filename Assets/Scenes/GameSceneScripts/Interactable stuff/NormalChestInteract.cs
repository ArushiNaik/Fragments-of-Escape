using UnityEngine;

public class NormalChestInteract : MonoBehaviour
{
    bool playerNearby = false;
    normalChest chestPuzzle;

    void Start()
    {
        chestPuzzle = GetComponent<normalChest>();
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
