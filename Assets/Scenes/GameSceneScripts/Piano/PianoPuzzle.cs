using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip noteC;
    public AudioClip noteDSharp;
    public AudioClip noteG;

    public GameObject rewardKey;

    private string[] correct = { "C", "D#", "G" };
    private int index = 0;

    public void PressKey(string note)
    {
        PlaySound(note);

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
            index = 0;
        }
    }

    void PlaySound(string note)
    {
        if (note == "C") audioSource.PlayOneShot(noteC);
        if (note == "D#") audioSource.PlayOneShot(noteDSharp);
        if (note == "G") audioSource.PlayOneShot(noteG);
    }

    void Solve()
    {
        if (rewardKey != null)
            rewardKey.SetActive(true);

        index = 0;
    }
}