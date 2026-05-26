using System.Collections;
using TMPro;
using UnityEngine;
using static CageAnim;

public class FinalDoorWin : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject messageUI;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private float messageDuration = 4f;

    [Header("References")]
    [SerializeField] private InteractableObject interactableObject;
    [SerializeField] private GameObject winPanel;

    [Header("Settings")]
    [SerializeField] private float delayBeforePanel = 15f;

    private bool triggered = false;

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        if (messageUI != null)
            messageUI.SetActive(false);
    }

    private void Update()
    {
        if (interactableObject == null || interactableObject.blockingCollider == null)
            return;

        if (!interactableObject.blockingCollider.enabled)
        {
            HandleDoorState();
        }
    }

    private void HandleDoorState()
    {
        if (triggered) return;

        if (!GameState.CageOpened)
        {
            ShowMessage("Save your friend first");
            return;
        }

        triggered = true;
        StartCoroutine(ShowWinPanel());
    }

    private void ShowMessage(string msg)
    {
        if (messageUI == null || messageText == null) return;

        messageUI.SetActive(true);
        messageText.text = msg;

        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), messageDuration);
    }

    private void HideMessage()
    {
        if (messageUI != null)
            messageUI.SetActive(false);
    }

    private IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(delayBeforePanel);

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}