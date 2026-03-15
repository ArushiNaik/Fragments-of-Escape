using UnityEngine;
using System.Collections;

public class FragmentRise : MonoBehaviour
{
    public float riseSpeed = 1.5f;
    public float riseHeight = 1.2f;

    private Vector3 startPos;
    private bool rising = false;
    private SpriteRenderer sr;

    void Start()
    {
        startPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    public void StartRise()
    {
        StartCoroutine(RiseDelay());
    }

    IEnumerator RiseDelay()
    {
        yield return new WaitForSeconds(1.5f);

        // bring fragment in front when it starts rising
        sr.sortingOrder = 10;

        rising = true;
    }

    void Update()
    {
        if (rising)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;

            if (transform.position.y >= startPos.y + riseHeight)
            {
                rising = false;
            }
        }
    }
}