using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public void PlayKey()
    { 
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
        
    }
}