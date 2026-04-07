using System.Collections.Generic;
using UnityEngine;

public class normalChest : MonoBehaviour
{

    public List<Sprite> requiredItems = new List<Sprite>(); // scalable item list
    public GameObject fragment;

    Animator animator;
    bool chestOpened = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
            animator.Play("ChestClosing");
    }

    public void TryOpenChest()
    {
        if (chestOpened)
        {
            GameMessageManager.instance.ShowMessage("The chest is already open.");
            return;
        }

        chestOpened = true;

        if (animator != null)
            animator.SetTrigger("OpenChest");

        fragment.SetActive(true);

        FragmentRise rise = fragment.GetComponent<FragmentRise>();
        if (rise != null)
            rise.StartRise();

        GameMessageManager.instance.ShowMessage("You found water!");
    }
}
