using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;

    public Slider healthSlider;

    void Start()
    {
        health = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (healthSlider != null)
            healthSlider.value = health;

        if (health <= 0)
        {
            GameManager.Instance.BossDefeated();
            Destroy(gameObject);
        }
    }
}