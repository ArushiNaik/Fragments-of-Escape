using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public string note; // D, E#, C etc
    public AudioClip sound;
    public AudioSource audioSource;
    public PianoPuzzleManager puzzleManager;

    public void PlayKey()
    {
        audioSource.PlayOneShot(sound);
        puzzleManager.RegisterNote(note);
    }
}