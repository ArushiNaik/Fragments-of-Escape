using UnityEngine;

public class KeyPuzzleController : MonoBehaviour
{
    [Header("Refs")]
    public KeyManager keyManager;

    [Header("UI")]
    public GameObject puzzlePanel;

    [Header("Pieces")]
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;

    void Start()
    {
        if (puzzlePanel != null)
        {
            puzzlePanel.SetActive(false);
        }
    }

    public void OpenPuzzle()
    {
        if (puzzlePanel != null)
        {
            puzzlePanel.SetActive(true);
        }

        // Show only collected fragments
        if (piece1 != null)
            piece1.SetActive(keyManager.hasFragment1);

        if (piece2 != null)
            piece2.SetActive(keyManager.hasFragment2);

        if (piece3 != null)
            piece3.SetActive(keyManager.hasFragment3);
    }

    // CALL THIS AFTER EACH SUCCESSFUL SNAP
    public void CheckCompletion()
    {
        // Player MUST have ALL fragments
        bool allFragmentsCollected =
            keyManager.hasFragment1 &&
            keyManager.hasFragment2 &&
            keyManager.hasFragment3;

        if (!allFragmentsCollected)
            return;

        // All pieces must be locked into place
        bool piece1Placed =
            piece1 != null &&
            piece1.activeSelf &&
            piece1.GetComponent<DraggablePiece>().locked;

        bool piece2Placed =
            piece2 != null &&
            piece2.activeSelf &&
            piece2.GetComponent<DraggablePiece>().locked;

        bool piece3Placed =
            piece3 != null &&
            piece3.activeSelf &&
            piece3.GetComponent<DraggablePiece>().locked;

        bool allPiecesPlaced =
            piece1Placed &&
            piece2Placed &&
            piece3Placed;

        if (allPiecesPlaced)
        {
            keyManager.CompleteKey();
        }
    }

    public void ClosePuzzle()
    {
        if (puzzlePanel != null)
        {
            puzzlePanel.SetActive(false);
        }
    }
}