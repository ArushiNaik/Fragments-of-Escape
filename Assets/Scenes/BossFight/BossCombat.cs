using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossCombat : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("UI")]
    public Slider healthSlider; 

    [Header("Target")]
    public Transform player;

    private MonsterMove move;
    private float attackTimer;
    public float attackCooldown = 2f;
    public float attackRange = 2f;

    private SpriteRenderer sr;
    private Color originalColor;

    void Awake()
    {
        move = GetComponent<MonsterMove>();
        sr = GetComponentInChildren<SpriteRenderer>();

        if (sr != null)
            originalColor = sr.color;

        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (move != null)
        {
            if (distance > attackRange)
                move.MoveTowards(player.position);
            else
                move.Stop();
        }

        attackTimer += Time.deltaTime;

        if (distance <= attackRange && attackTimer >= attackCooldown)
        {
            PlayerHealth ph = player.GetComponent<PlayerHealth>();
            if (ph != null)
                ph.TakeDamage(1);

            attackTimer = 0f;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        StartCoroutine(HitFlash());

        if (currentHealth <= 0)
        {
            GameManager.Instance.BossDefeated();
            Destroy(gameObject);
        }
    }

    IEnumerator HitFlash()
    {
        if (sr == null) yield break;

        sr.color = Color.black;
        yield return new WaitForSeconds(0.15f);
        sr.color = originalColor;
    }
}