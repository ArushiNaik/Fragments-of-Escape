using UnityEngine;

public class PianoInteract : MonoBehaviour
{
    public GameObject pianoPanel;

    private bool playerNear = false;

    void Update()
    {
        if (playerNear)
        {
            InteractionPromptUI.instance.ShowPrompt();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("OPEN");
                pianoPanel.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            playerNear = false;
            InteractionPromptUI.instance.HidePrompt();
        }
    }
}