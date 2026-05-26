using UnityEngine;
using System.Collections;

public class GameWon : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject gameWon;

    private bool opened = false;

    private void Start()
    {
        gameWon.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !opened)
        {
            opened = true;

            doorAnim.SetTrigger("Open");

            StartCoroutine(ShowWinPanel());
        }
    }

    IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(2f);

        gameWon.SetActive(true);
    }
}