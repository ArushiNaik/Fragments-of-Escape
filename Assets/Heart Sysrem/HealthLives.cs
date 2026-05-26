using UnityEngine;

public class HealthLives : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject heartBlack;
    public GameObject heartBlack2;
    public GameObject heartBlack3;

    public int lives = 3;

    void Start()
    {
        heartBlack.SetActive(false);
        heartBlack2.SetActive(false);
        heartBlack3.SetActive(false);
    }

    void Update()
    {
        if (lives == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);

            heartBlack.SetActive(false);
            heartBlack2.SetActive(false);
            heartBlack3.SetActive(false);
        }

        if (lives == 2)
        {
            heart1.SetActive(false);
            heartBlack.SetActive(true);
        }

        if (lives == 1)
        {
            heart2.SetActive(false);
            heartBlack2.SetActive(true);
        }

        if (lives <= 0)
        {
            heart3.SetActive(false);
            heartBlack3.SetActive(true);
        }
    }
}