using UnityEngine;

public class FragmentRise : MonoBehaviour
{
    public float riseSpeed = 1.5f;
    public float riseHeight = 1.2f;

    private Vector3 startPos;
    private bool rising = false;

    void Start()
    {
        startPos = transform.position;
    }

    public void StartRise()
    {
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