//using UnityEngine;

//public class ChestWithLock : Interactable
//{
//    [Header("UI")]
//    public GameObject lockPanel;

//    private bool isSolved = false;

//    public override void Interact()
//    {
//        // Prevent reopening after solved
//        if (isSolved)
//            return;

//        if (lockPanel == null)
//        {
//            Debug.LogError("LockPanel not assigned!");
//            return;
//        }

//        lockPanel.SetActive(true);
//    }

//    // Call this when puzzle is solved
//    public void MarkSolved()
//    {
//        isSolved = true;
//    }
//}

using UnityEngine;

public class ChestWithLock : Interactable
{
   public GameObject lockPanel;
    public Animator animator;

    private bool isSolved = false;

    public override void Interact()
    {
       if (isSolved)
        {
            OpenChest();
            return;
        }

        if (lockPanel == null)
        {
            Debug.LogError("LockPanel not assigned!");
            return;
        }

        lockPanel.SetActive(true);
    }
   public void MarkSolved()
    {
        isSolved = true;
        lockPanel.SetActive(false);

        GameMessageManager.instance.ShowMessage("Chest open");
    }

    void OpenChest()
    {
        if (animator != null)
            animator.SetTrigger("Open");

        GameMessageManager.instance.ShowMessage("Chest already opened");
    }
}