using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public HealthLives livesUI;

    public GameCycleManager cycleManager;

    bool touched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster") && !touched)
        {
            touched = true;

            livesUI.lives--;

            cycleManager.PlayerCaught();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            touched = false;
        }
    }
}