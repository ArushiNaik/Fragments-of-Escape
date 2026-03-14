using UnityEngine;

public class ChestPuzzle : MonoBehaviour
{
    public Sprite featherSprite;
    public Sprite flameSprite;
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

        if (InventoryManager.instance.HasItem(featherSprite) &&
            InventoryManager.instance.HasItem(flameSprite))
        {
            chestOpened = true;

            if (animator != null)
                animator.SetTrigger("OpenChest");

            fragment.SetActive(true);

            FragmentRise rise = fragment.GetComponent<FragmentRise>();
            if (rise != null)
                rise.StartRise();

            InventoryManager.instance.RemoveItem(featherSprite);
            InventoryManager.instance.RemoveItem(flameSprite);

            GameMessageManager.instance.ShowMessage("You found the painting fragment!");
        }
        else
        {
            GameMessageManager.instance.ShowMessage("You need Feather and Flame.");
        }
    }
}