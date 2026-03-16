using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzleManager : MonoBehaviour
{
    public List<string> correctSequence = new List<string> { "D", "F#", "C" };

    private List<string> playerSequence = new List<string>();

    public GameObject unlockKey; // the key that appears

    void Start()
    {
        unlockKey.SetActive(false);
    }

    public void RegisterNote(string note)
    {
        playerSequence.Add(note);

        if (playerSequence[playerSequence.Count - 1] != correctSequence[playerSequence.Count - 1])
        {
            // wrong note → reset
            playerSequence.Clear();
            return;
        }

        if (playerSequence.Count == correctSequence.Count)
        {
            PuzzleSolved();
        }
    }

    void PuzzleSolved()
    {
        Debug.Log("Piano puzzle solved!");
        unlockKey.SetActive(true);
        playerSequence.Clear();
    }
}