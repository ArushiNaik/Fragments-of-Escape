using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool soundOn = true;
    public TextMeshProUGUI soundText;

    public void PlayGame()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void ToggleSound() {
        soundOn = !soundOn;
        AudioListener.volume = soundOn ? 1 : 0;
        soundText.text = soundOn ? "Sound : ON" : "Sound : OFF";

            }

    public void QuitGame()
    {
        Application.Quit();
    }

    public GameObject rulesPanel;
    public GameObject controlsPanel;
    public void OpenRules()
    {
        rulesPanel.SetActive(true);
    }

    public void CloseRules()
    {
        rulesPanel.SetActive(false);
    }

    public void OpenControls()
    {
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
    }

}
