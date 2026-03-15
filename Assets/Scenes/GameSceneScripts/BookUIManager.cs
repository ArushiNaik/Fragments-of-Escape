using UnityEngine;
using TMPro;

public class BookUIManager : MonoBehaviour
{
    public static BookUIManager instance;

    public GameObject bookPanel;
    public TMP_Text bookText;

    void Awake()
    {
        instance = this;
        bookPanel.SetActive(false);
    }

    public void OpenBook(string text)
    {
        bookPanel.SetActive(true);
        bookText.text = text;

        Time.timeScale = 0f; // pause game
    }

    public void CloseBook()
    {
        bookPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
