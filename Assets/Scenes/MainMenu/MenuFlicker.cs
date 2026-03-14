using UnityEngine;

public class MenuFlicker : MonoBehaviour
{
    public CanvasGroup target;
    public float flickerSpeed = 0.5f;

    void Update()
    {
        float flicker = 0.95f + Mathf.PerlinNoise(Time.time * flickerSpeed, 0f) * 0.05f;
        target.alpha = flicker;
    }
}