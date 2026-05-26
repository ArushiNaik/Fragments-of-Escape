using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartButton(){
        SceneManager.LoadScene("Game");
    }

    public void ExitButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
