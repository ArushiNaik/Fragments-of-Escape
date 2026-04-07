using UnityEngine;

public class PianoInteract : MonoBehaviour
{
    public PianoPuzzle pianoPuzzle;

    private bool playerNear = false;

    void Update()
    {
        if (!playerNear) return;

        if (InteractionPromptUI.instance != null)
            InteractionPromptUI.instance.ShowPrompt();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pianoPuzzle != null)
            {
                Debug.Log("OPEN");
                pianoPuzzle.OpenPiano();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            playerNear = true;

            if (InteractionPromptUI.instance != null)
                InteractionPromptUI.instance.ShowPrompt();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            playerNear = false;

            if (InteractionPromptUI.instance != null)
                InteractionPromptUI.instance.HidePrompt();
        }
    }
}