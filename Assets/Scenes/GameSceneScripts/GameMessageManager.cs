//using UnityEngine;
//using TMPro;

//public class GameMessageManager : MonoBehaviour
//{
//    public static GameMessageManager instance;

//    public TextMeshProUGUI messageText;

//    void Awake()
//    {
//        instance = this;
//    }

//    public void ShowMessage(string message)
//    {
//        messageText.text = message;
//        CancelInvoke();
//        Invoke(nameof(ClearMessage), 3f);
//    }

//    void ClearMessage()
//    {
//        messageText.text = "";
//    }
//}

using UnityEngine;
using TMPro;

public class GameMessageManager : MonoBehaviour
{
    public static GameMessageManager instance;
    public TextMeshProUGUI messageText;

    private bool isPersistent = false;

    void Awake()
    {
        instance = this;
    }

    // Normal message: auto-clears after 3 seconds
    public void ShowMessage(string message)
    {
        isPersistent = false;
        messageText.text = message;
        CancelInvoke();
        Invoke(nameof(ClearMessage), 3f);
    }

    // Persistent message: stays until ClearMessage is called manually
    public void ShowPersistentMessage(string message)
    {
        isPersistent = true;
        CancelInvoke();
        messageText.text = message;
    }

    public void ClearMessage()
    {
        isPersistent = false;
        messageText.text = "";
    }
}