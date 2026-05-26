using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenu;

    private GameInputActions inputActions;

    void Awake()
    {
        inputActions = new GameInputActions();
        inputActions.player.Enable();
        inputActions.player.Pause.performed += ctx => TogglePause();
    }

    void OnDestroy()
    {
        inputActions.player.Disable();
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void TogglePause()
    {
        if (GameIsPaused)
            Resume();
        else
            unResume();
    }

    public void unResume()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PauseMenu : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     public static bool GameIsPaused;
//     public GameObject pauseMenu;

//     void start(){
//         pauseMenu.SetActive(false);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Escape)){
//             if(GameIsPaused){
//                 Resume();
//             }else{
//                 unResume();
//             }
//         }
//     }

//         public void unResume(){
//         pauseMenu.SetActive(true);
//         Time.timeScale = 0;
//         GameIsPaused=true;
//     }

//         public void Resume(){
//         pauseMenu.SetActive(false);
//         Time.timeScale = 1f;
//         GameIsPaused=false;
//     }

//     public void QuitGame(){
//         Debug.Log("Game Quit");
//         //Application.Quit();
//         SceneManager.LoadScene("MainMenu");
//     }
// }
