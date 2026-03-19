using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PianoPuzzle : MonoBehaviour
{
    public Image keyC;
    public Image keyDSharp;
    public Image keyG;
    private bool isResetting = false;
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;

    public GameObject pianoPanel;

    public AudioSource audioSource;
    public AudioClip noteC;
    public AudioClip noteDSharp;
    public AudioClip noteG;

    public GameObject rewardKey;

    private string[] correct = { "C", "D#", "G" };
    private int index = 0;

    public void PressKey(string note)
    {
        if (isResetting) return; // 🛑 block input during reset

        PlaySound(note);

        if (index >= correct.Length)
            index = 0;

        if (note == correct[index])
        {
            index++;

            if (index == correct.Length)
            {
                Solve();
            }
        }
        else
        {
            StartCoroutine(WrongRoutine());
        }
    }

    void PlaySound(string note)
    {
        if (audioSource == null) return;

        if (note == "C") audioSource.PlayOneShot(noteC);
        if (note == "D#") audioSource.PlayOneShot(noteDSharp);
        if (note == "G") audioSource.PlayOneShot(noteG);
    }

    void Solve()
    {
        Debug.Log("Solve triggered");

        if (keyC == null) Debug.LogError("keyC NULL");
        if (keyDSharp == null) Debug.LogError("keyDSharp NULL");
        if (keyG == null) Debug.LogError("keyG NULL");
        if (rewardKey == null) Debug.LogError("rewardKey NULL");
        if (pianoPanel == null) Debug.LogError("pianoPanel NULL");
        if (GameMessageManager.instance == null) Debug.LogError("GameMessageManager NULL");

        if (keyC != null) keyC.color = correctColor;
        if (keyDSharp != null) keyDSharp.color = correctColor;
        if (keyG != null) keyG.color = correctColor;

        if (GameMessageManager.instance != null)
            GameMessageManager.instance.ShowMessage("Yay! Puzzle Solved!");

        if (rewardKey != null)
            rewardKey.SetActive(true);

        StartCoroutine(CloseAfterDelay());
    }

    IEnumerator WrongRoutine()
    {
        isResetting = true;

        //  turn red
        if (keyC != null) keyC.color = wrongColor;
        if (keyDSharp != null) keyDSharp.color = wrongColor;
        if (keyG != null) keyG.color = wrongColor;

        if (GameMessageManager.instance != null)
            GameMessageManager.instance.ShowMessage("Wrong combination!");

        // wait 2 sec
        yield return new WaitForSeconds(2f);

        //  reset
        ResetSequence();

        isResetting = false;
    }

    IEnumerator CloseAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        if (pianoPanel != null)
            pianoPanel.SetActive(false);
    }

    public void ResetSequence()
    {
        index = 0;

        if (keyC != null) keyC.color = Color.white;
        if (keyDSharp != null) keyDSharp.color = Color.white;
        if (keyG != null) keyG.color = Color.white;
    }
}