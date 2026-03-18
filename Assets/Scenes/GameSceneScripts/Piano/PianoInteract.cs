using UnityEngine;
using TMPro;

public class PianoInteract : MonoBehaviour
{
    public GameObject pianoPanel;
    public TMP_Text interactionText;

    private bool playerNear = false;
    private bool isOpen = false;

    void Start()
    {
        // Ensure panel starts closed
        if (pianoPanel != null)
            pianoPanel.SetActive(false);
    }

    void Update()
    {
        // Open ONLY once
        if (playerNear && !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Opening piano");
            OpenPanel();
        }
    }

    void OpenPanel()
    {
        if (pianoPanel == null)
        {
            Debug.LogError("PianoPanel not assigned!");
            return;
        }

        isOpen = true;
        pianoPanel.SetActive(true);

        if (interactionText != null)
            interactionText.text = "";
    }

    public void ClosePanel()
    {
        Debug.Log("Closing piano");

        if (pianoPanel != null)
            pianoPanel.SetActive(false);

        isOpen = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Player entered");

            playerNear = true;

            if (interactionText != null && !isOpen)
                interactionText.text = "Press E to play piano";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Player exited");

            playerNear = false;

            if (interactionText != null)
                interactionText.text = "";
        }
    }
}