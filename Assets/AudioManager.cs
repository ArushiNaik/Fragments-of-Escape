using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundAmbiance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundAmbiance.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
