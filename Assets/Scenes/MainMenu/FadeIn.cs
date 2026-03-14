using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float duration = 1f;

    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float t = duration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            fadeGroup.alpha = t / duration;
            yield return null;
        }
    }
}