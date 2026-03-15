using UnityEngine;

public class CloseBookButton : MonoBehaviour
{
    public void CloseBook()
    {
        BookUIManager.instance.CloseBook();
    }
}
