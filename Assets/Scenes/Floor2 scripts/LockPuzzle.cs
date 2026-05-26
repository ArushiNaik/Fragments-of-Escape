using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class LockPuzzle : MonoBehaviour
{
    [Header("Wheels")]
    public LockWheel[] wheels;

    [Header("UI")]
    public GameObject panel;
    public TMP_Text feedbackText;

    [Header("Chest")]
    public Animator chestAnimator;
    public GameObject fragmentPrefab;
    public Transform spawnPoint;

    private int selectedIndex = 0;
    private int[] correctCode = { 3, 9, 7 };
    private bool solved = false;
    private bool playerNearby = false;
    private float inputCooldown = 0.15f;
    private float lastInputTime;

    private GameInputActions inputActions;

    void Awake()
    {
        inputActions = new GameInputActions();
        inputActions.player.Enable();
        inputActions.player.Interact.performed += ctx => OnInteract();
    }

    void OnDestroy()
    {
        inputActions.player.Disable();
    }

    void OnInteract()
    {
        if (!playerNearby || solved || panel.activeSelf) return;
        OpenPuzzle();
    }

    void Update()
    {
        if (!panel.activeSelf || solved) return;

        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.leftArrowKey.wasPressedThisFrame)
        {
            selectedIndex = Mathf.Max(0, selectedIndex - 1);
            UpdateSelection();
        }

        if (kb.rightArrowKey.wasPressedThisFrame)
        {
            selectedIndex = Mathf.Min(wheels.Length - 1, selectedIndex + 1);
            UpdateSelection();
        }

        if (Time.time - lastInputTime > inputCooldown)
        {
            if (kb.upArrowKey.wasPressedThisFrame)
            {
                wheels[selectedIndex].ScrollUp();
                lastInputTime = Time.time;
            }
            if (kb.downArrowKey.wasPressedThisFrame)
            {
                wheels[selectedIndex].ScrollDown();
                lastInputTime = Time.time;
            }
        }

        if (kb.enterKey.wasPressedThisFrame)
            CheckCode();
    }

    void OpenPuzzle()
    {
        panel.SetActive(true);
        solved = false;
        selectedIndex = 0;
        UpdateSelection();
        if (feedbackText != null) feedbackText.text = "";
    }

    void ClosePuzzle()
    {
        panel.SetActive(false);
    }

    void UpdateSelection()
    {
        for (int i = 0; i < wheels.Length; i++)
            wheels[i].SetSelected(i == selectedIndex);
    }

    void CheckCode()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            if (wheels[i].GetValue() != correctCode[i])
            {
                StopAllCoroutines();
                StartCoroutine(ShowWrong());
                return;
            }
        }
        StopAllCoroutines();
        StartCoroutine(SolveSequence());
    }

    IEnumerator ShowWrong()
    {
        if (feedbackText != null) feedbackText.text = "Wrong Combination";
        yield return new WaitForSeconds(1.5f);
        if (feedbackText != null) feedbackText.text = "";
    }

    IEnumerator SolveSequence()
    {
        solved = true;
        if (feedbackText != null) feedbackText.text = "Chest Unlocked!";
        yield return new WaitForSeconds(1.5f);
        ClosePuzzle();
        if (chestAnimator != null) chestAnimator.SetTrigger("Open");
        if (fragmentPrefab != null && spawnPoint != null)
            Instantiate(fragmentPrefab, spawnPoint.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerNearby = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (panel.activeSelf) ClosePuzzle();
        }
    }
}

// public class LockPuzzle : MonoBehaviour
// {
//     [Header("Wheels")]
//     public LockWheel[] wheels;

//     [Header("Player")]
//     public MonoBehaviour playerController;

//     [Header("UI")]
//     public GameObject panel;
//     public Text feedbackText;

//     [Header("Chest")]
//     public Animator chestAnimator;
//     public GameObject fragmentPrefab;
//     public Transform spawnPoint;

//     private int selectedIndex = 0;
//     private int[] correctCode = { 3, 9, 7 };
//     private bool solved = false;
//     private float inputCooldown = 0.15f;
//     private float lastInputTime;

//     void Update()
//     {
//         if (!panel.activeSelf || solved) return;

//         // Switch wheel selection
//         if (Input.GetKeyDown(KeyCode.LeftArrow))
//         {
//             selectedIndex = Mathf.Max(0, selectedIndex - 1);
//             UpdateSelection();
//         }
//         if (Input.GetKeyDown(KeyCode.RightArrow))
//         {
//             selectedIndex = Mathf.Min(wheels.Length - 1, selectedIndex + 1);
//             UpdateSelection();
//         }

//         // Scroll wheel values
//         if (Time.time - lastInputTime > inputCooldown)
//         {
//             if (Input.GetKeyDown(KeyCode.UpArrow))
//             {
//                 wheels[selectedIndex].ScrollUp();
//                 lastInputTime = Time.time;
//             }
//             if (Input.GetKeyDown(KeyCode.DownArrow))
//             {
//                 wheels[selectedIndex].ScrollDown();
//                 lastInputTime = Time.time;
//             }
//         }

//         // Submit code
//         if (Input.GetKeyDown(KeyCode.Return))
//         {
//             CheckCode();
//         }
//     }

//     public void OpenPuzzle()
//     {
//         panel.SetActive(true);
//         solved = false;

//         // Disable player movement
//         if (playerController != null)
//             playerController.enabled = false;

//         // Ensure cursor is visible (2D game = always visible)
//         Cursor.lockState = CursorLockMode.None;
//         Cursor.visible = true;

//         // Initialize puzzle
//         selectedIndex = 0;
//         UpdateSelection();
//         feedbackText.text = "";
//     }

//     public void ClosePuzzle()
//     {
//         panel.SetActive(false);

//         // Re-enable player movement
//         if (playerController != null)
//             playerController.enabled = true;

//         // Keep cursor visible (DO NOT LOCK in 2D)
//         Cursor.lockState = CursorLockMode.None;
//         Cursor.visible = true;
//     }

//     void UpdateSelection()
//     {
//         for (int i = 0; i < wheels.Length; i++)
//         {
//             wheels[i].SetSelected(i == selectedIndex);
//         }
//     }

//     void CheckCode()
//     {
//         for (int i = 0; i < wheels.Length; i++)
//         {
//             if (wheels[i].GetValue() != correctCode[i])
//             {
//                 StopAllCoroutines();
//                 StartCoroutine(ShowWrong());
//                 return;
//             }
//         }

//         StopAllCoroutines();
//         StartCoroutine(SolveSequence());
//     }

//     private IEnumerator ShowWrong()
//     {
//         feedbackText.text = "Wrong Combination";
//         yield return new WaitForSeconds(1.5f);
//         feedbackText.text = "";
//     }

//     private IEnumerator SolveSequence()
//     {
//         solved = true;
//         feedbackText.text = "Chest Unlocked!";
//         yield return new WaitForSeconds(1.5f);

//         ClosePuzzle();

//         if (chestAnimator != null)
//             chestAnimator.SetTrigger("Open");

//         if (fragmentPrefab != null && spawnPoint != null)
//             Instantiate(fragmentPrefab, spawnPoint.position, Quaternion.identity);
//     }
// }