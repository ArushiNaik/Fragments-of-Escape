using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool soundOn = true;

    public void PlayGame()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void ToggleSound() {
        soundOn = !soundOn;
        AudioListener.volume = soundOn ? 1 : 0;

            }

    public void QuitGame()
    {
        Application.Quit();
    }

    public GameObject rulesPanel;

    public void OpenRules()
    {
        rulesPanel.SetActive(true);
    }

    public void CloseRules()
    {
        rulesPanel.SetActive(false);
    }

}
