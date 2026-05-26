using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCycleManager : MonoBehaviour
{
    [Header("Monster")]
    public GameObject monster;

    [Header("Player")]
    public Transform player;
    public Transform playerSpawnPoint;

    [Header("UI")]
    public TextMeshProUGUI timerText;

    public GameObject loseLifePanel;

    public GameObject gameOverPanel;

    [Header("Lives")]
    public HealthLives healthLives;

    [Header("Times")]
    public float safeTime = 60f;

    public float chaseTime = 30f;

    float currentTime;

    bool chasing = false;

    bool bossDefeated = false;

    [Header("Audio")]
    public AudioSource evilLaugh;
    public AudioSource screamGirl;


    bool paused = false;
    private MonsterMove monsterMove;
    void Start()
    {
        monsterMove = monster.GetComponent<MonsterMove>();

        monster.SetActive(false);

        loseLifePanel.SetActive(false);

        gameOverPanel.SetActive(false);

        StartSafePhase();
    }

    void Update()
    {
        if (bossDefeated || paused)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime < 0)
            currentTime = 0;

        UpdateTimer();

        if (chasing)
        {
            monsterMove.MoveTowards(player.position);
        }

        if (currentTime <= 0)
        {
            if (!chasing)
            {
                StartChase();
            }
            else
            {
                EndChase();
            }
        }
    }

    void StartSafePhase()
    {
        chasing = false;

        monster.SetActive(false);

        currentTime = safeTime;

        timerText.color = Color.white;
    }

    void StartChase()
    {
        chasing = true;

        monster.SetActive(true);

        currentTime = chaseTime;

        timerText.color = Color.red;
    }

    void EndChase()
    {
        chasing = false;

        monsterMove.Stop();

        monster.SetActive(false);

        currentTime = safeTime;

        timerText.color = Color.white;
    }

    void UpdateTimer()
    {
        int minutes =
            Mathf.FloorToInt(currentTime / 60);

        int seconds =
            Mathf.FloorToInt(currentTime % 60);

        timerText.text =
            string.Format("{0:00}:{1:00}",
            minutes,
            seconds);
    }

    public void PlayerCaught()
    {
        paused = true;

        monster.SetActive(false);

        player.position =
            playerSpawnPoint.position;

        if (healthLives.lives <= 0)
        {
            gameOverPanel.SetActive(true);
            

            if(gameOverPanel.activeSelf){
                screamGirl.Play();
            }

            if(!gameOverPanel.activeSelf){
                screamGirl.Stop();
            }

            Invoke(nameof(PauseGame), 0.2f);

            return;
        }

        loseLifePanel.SetActive(true);
            if (loseLifePanel.activeSelf)
            {
                evilLaugh.Play();
            }
            if (!loseLifePanel.activeSelf)
                {
                    evilLaugh.Stop();
                }

        Invoke(nameof(PauseGame), 0.2f);

        // Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        loseLifePanel.SetActive(false);

        Time.timeScale = 1f;

        paused = false;

        StartSafePhase();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }

    public void BossKilled()
    {
        bossDefeated = true;

        monster.SetActive(false);

        timerText.text = "";
    }

void PauseGame()
{
    Time.timeScale = 0f;
}

}