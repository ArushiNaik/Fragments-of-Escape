using UnityEngine;
using TMPro;

public class GameMessageManager : MonoBehaviour
{
    public static GameMessageManager instance;

    public TextMeshProUGUI messageText;

    void Awake()
    {
        instance = this;
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        CancelInvoke();
        Invoke(nameof(ClearMessage), 3f);
    }

    void ClearMessage()
    {
        messageText.text = "";
    }
}