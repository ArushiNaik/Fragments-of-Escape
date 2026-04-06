using UnityEngine;

public class ChestWithLock : Interactable
{
    [Header("UI")]
    public GameObject lockPanel;

    private bool isSolved = false;

    protected override void Interact()
    {
        // Prevent reopening after solved
        if (isSolved)
            return;

        if (lockPanel == null)
        {
            Debug.LogError("LockPanel not assigned!");
            return;
        }

        lockPanel.SetActive(true);
    }

    // Call this when puzzle is solved
    public void MarkSolved()
    {
        isSolved = true;
    }
}