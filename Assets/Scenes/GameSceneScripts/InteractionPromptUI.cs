using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    public static InteractionPromptUI instance;

    public GameObject promptUI;

    void Awake()
    {
        instance = this;
        promptUI.SetActive(false);
    }

    public void ShowPrompt()
    {
        promptUI.SetActive(true);
    }

    public void HidePrompt()
    {
        promptUI.SetActive(false);
    }

}