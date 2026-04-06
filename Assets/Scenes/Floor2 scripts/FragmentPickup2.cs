using UnityEngine;
using System.Collections;

public class FragmentPickup2 : Interactable
{
    [Header("Movement")]
    public float riseHeight = 1.5f;
    public float riseSpeed = 2f;

    public float fallOffset = -0.6f;
    public float fallSpeed = 0.5f;

    public float floatAmplitude = 0.15f;
    public float floatSpeed = 2f;

    public Sprite itemSprite;

    private Vector3 startPos;
    private Vector3 topPos;
    private Vector3 finalPos;

    private bool floating = false;

    void Start()
    {
        startPos = transform.position;
        topPos = startPos + Vector3.up * riseHeight;
        finalPos = startPos + Vector3.up * fallOffset;

        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        // Rise
        while (Vector3.Distance(transform.position, topPos) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, topPos, Time.deltaTime * riseSpeed);
            yield return null;
        }

        transform.position = topPos;

        // Fall
        while (Vector3.Distance(transform.position, finalPos) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * fallSpeed);
            yield return null;
        }

        transform.position = finalPos;
        floating = true;
    }

    void Update()
    {
        // Rotate
        transform.Rotate(0, 50f * Time.deltaTime, 0);

        // Float
        if (floating)
        {
            float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

            transform.position = new Vector3(
                finalPos.x,
                finalPos.y + yOffset,
                finalPos.z
            );
        }
    }

    protected override void Interact()
    {
        Debug.Log("Fragment Collected!");

        if (InventoryManager.instance != null)
        {
            InventoryManager.instance.AddItem(itemSprite);
        }

        Destroy(gameObject);
    }
}