using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public bool filled;
    public GameObject currentPiece;

    public KeyPuzzleController controller;

    public void PlacePiece(GameObject piece)
    {
        currentPiece = piece;
        filled = true;

        piece.transform.position = transform.position;

        controller.CheckCompletion();
    }
}