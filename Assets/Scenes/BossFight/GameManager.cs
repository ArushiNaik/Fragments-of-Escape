using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float originalCameraSize;
    private Vector3 savedPlayerPosition;

    [Header("Boss Arena")]
    public Transform bossPlayerSpawn;
    public Transform bossMonsterSpawn;
    public Transform bossHandPoint;

    [Header("Camera")]
    public Camera mainCamera;
    public float bossCameraSize = 8f;

    [Header("UI")]
    public GameObject startPanel;
    public GameObject deathPanel;
    public GameObject winPanel;
    public float fragmentDelayAfterWin = 1f;

    [Header("World")]
    public GameObject playerNormal;
    public GameObject monsterNormal;
    public GameObject playerBoss;
    public GameObject monsterBoss;

    [Header("UI Boss")]
    public GameObject playerHealthBar;
    public GameObject bossHealthBar;

    [Header("Gun")]
    public GameObject currentGun;

    [Header("Win Reward")]
    public GameObject finalFragmentPrefab;
    public Transform finalFragmentSpawnPoint;

    bool bossStarted;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;

        if (mainCamera != null)
        {
            originalCameraSize = mainCamera.orthographicSize;
        }
    }

    Transform GetPlayerVisual(GameObject player)
    {
        Transform visual = player.transform.Find("PlayerVisual");
        return visual != null ? visual : player.transform;
    }

    void SetCameraTarget(GameObject player)
    {
        if (mainCamera == null) return;

        var follow = mainCamera.GetComponent<CameraFollow>();
        if (follow == null) return;

        follow.enabled = true;
        follow.target = GetPlayerVisual(player);
    }
    public void StartBossSequence()
    {
        if (bossStarted) return;

        savedPlayerPosition = playerNormal.transform.position;

        bossStarted = true;
        StartCoroutine(BossIntro());
    }


    IEnumerator BossIntro()
    {
        Time.timeScale = 1f;

        var normalPC = playerNormal.GetComponent<PlayerController>();
        if (normalPC != null) normalPC.DisableControl();

        startPanel?.SetActive(true);
        yield return new WaitForSeconds(3f);
        startPanel?.SetActive(false);

        playerBoss.transform.position = bossPlayerSpawn.position;
        monsterBoss.transform.position = bossMonsterSpawn.position;

        playerBoss.SetActive(true);
        monsterBoss.SetActive(true);

        playerNormal.SetActive(false);
        monsterNormal.SetActive(false);

        // if (currentGun != null && bossHandPoint != null)
        // {
        //     currentGun.SetActive(true);

           
        //     currentGun.transform.SetParent(bossHandPoint, false);
        //     currentGun.transform.localPosition = Vector3.zero;
        //     currentGun.transform.localRotation = Quaternion.identity;
        //     currentGun.transform.localScale = Vector3.one * 0.3f;

        //     playerBoss.GetComponent<PlayerController>()?.SetArmed();
        // }
            if (currentGun != null && bossHandPoint != null)
{
    currentGun.SetActive(true);
     GunPickup gp = currentGun.GetComponent<GunPickup>();
            if (gp != null)
                gp.ConvertToHeld();

    currentGun.transform.SetParent(bossHandPoint, false);
    currentGun.transform.localPosition = Vector3.zero;
    currentGun.transform.localRotation = Quaternion.identity;
    currentGun.transform.localScale = Vector3.one * 0.3f;

    playerBoss.GetComponent<PlayerController>()?.SetArmed();
}
        var bossMove = playerBoss.GetComponent<PlayerMovement>();
        if (bossMove != null) bossMove.enabled = false;

        var bossPC = playerBoss.GetComponent<PlayerController>();
        if (bossPC != null)
        {
            bossPC.enabled = true;
            bossPC.EnableControl();
        }

        monsterBoss.GetComponent<BossCombat>().player = playerBoss.transform;

        playerHealthBar?.SetActive(true);
        bossHealthBar?.SetActive(true);

        SetCameraTarget(playerBoss);
        mainCamera.orthographicSize = bossCameraSize;
    }

    public void BossDefeated()
    {
        GunShooter gun = currentGun.GetComponent<GunShooter>();

        if (gun != null)
        {
            gun.StopShooting();
        }

        playerBoss.SetActive(false);
        monsterBoss.SetActive(false);

        playerNormal.SetActive(true);
        monsterNormal.SetActive(true);

        playerNormal.transform.position = savedPlayerPosition;

        playerNormal.GetComponent<PlayerController>()?.EnableControl();

        playerHealthBar?.SetActive(false);
        bossHealthBar?.SetActive(false);

        SetCameraTarget(playerNormal);

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = originalCameraSize;
        }

        StartCoroutine(WinSequence());
    }



    IEnumerator WinSequence()
    {
        winPanel?.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(fragmentDelayAfterWin);

        if (finalFragmentPrefab != null && finalFragmentSpawnPoint != null)
        {
            Instantiate(
                finalFragmentPrefab,
                finalFragmentSpawnPoint.position,
                Quaternion.identity
            );
        }
    }


    public void ContinueGame()
    {
        winPanel?.SetActive(false);
        Time.timeScale = 1f;

        SetCameraTarget(playerNormal);

        playerNormal.GetComponent<PlayerController>()?.EnableControl();

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = originalCameraSize;
        }
    }

    public void RestartBossFight()
    {
        StartCoroutine(RestartRoutine());
    }

    IEnumerator RestartRoutine()
    {
        Time.timeScale = 1f;

        deathPanel?.SetActive(false);
        winPanel?.SetActive(false);

        playerBoss.SetActive(false);
        monsterBoss.SetActive(false);

        playerNormal.SetActive(true);
        monsterNormal.SetActive(true);

        playerHealthBar?.SetActive(false);
        bossHealthBar?.SetActive(false);

        bossStarted = false;

        yield return new WaitForSeconds(0.2f);

        StartBossSequence();
    }

    public void SaveCheckpoint(Vector3 playerPos)
    {
        savedPlayerPosition = playerPos;
    }

    public void PlayTracer(GameObject tracerPrefab, Vector3 start, Vector2 target, float speed)
    {
        StartCoroutine(TracerRoutine(tracerPrefab, start, target, speed));
    }

    IEnumerator TracerRoutine(GameObject tracerPrefab, Vector3 start, Vector2 target, float speed)
    {
        GameObject tracer = Instantiate(tracerPrefab, start, Quaternion.identity);

        float distance = Vector2.Distance(start, target);
        float travelTime = distance / speed;

        float t = 0f;

        while (t < travelTime)
        {
            tracer.transform.position = Vector3.Lerp(start, target, t / travelTime);
            t += Time.deltaTime;
            yield return null;
        }

        tracer.transform.position = target;
        Destroy(tracer);
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;

        if (deathPanel != null)
            deathPanel.SetActive(true);
    }
}