using UnityEngine;

public class KeyDrop : MonoBehaviour
{
    public float dropSpeed = 2f;
    public float dropDistance = 1.5f;

    private Vector3 startPos;
    private bool dropping = false;

    void OnEnable()
    {
        startPos = transform.position;
        Invoke("StartDrop", 0.5f); // delay
    }

    void StartDrop()
    {
        dropping = true;
    }

    void Update()
    {
        if (!dropping) return;

        transform.position += Vector3.down * dropSpeed * Time.deltaTime;

        if (transform.position.y <= startPos.y - dropDistance)
        {
            dropping = false;
        }
    }
}