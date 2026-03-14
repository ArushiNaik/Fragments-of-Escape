using UnityEngine;

public class SlowDrift : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}