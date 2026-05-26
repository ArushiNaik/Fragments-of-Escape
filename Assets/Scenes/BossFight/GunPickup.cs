//using System.Collections;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class GunPickup : Interactable
//{
//    [Header("Float")]
//    public float riseHeight = 1.5f;
//    public float riseSpeed = 2f;
//    public float floatAmplitude = 0.2f;
//    public float floatSpeed = 2f;
//    public float rotateSpeed = 60f;

//    private Vector3 basePos;
//    private bool raised;
//    private bool pickedUp;
//    private float t;

//    private GameInputActions inputActions;

//    protected override void Awake()
//    {
//        inputActions = new GameInputActions();
//        inputActions.player.Enable();
//        inputActions.player.Interact.performed += ctx => TryPickup();
//    }

//    protected override void OnDestroy()
//    {
//        inputActions.player.Disable();
//    }

//    void Start()
//    {
//        basePos = transform.position;
//    }

//    void Update()
//    {
//        if (pickedUp) return;

//        if (!raised)
//        {
//            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
//            if (transform.position.y >= basePos.y + riseHeight)
//            {
//                raised = true;
//                basePos = transform.position;
//            }
//        }
//        else
//        {
//            t += Time.deltaTime;
//            float y = Mathf.Sin(t * floatSpeed) * floatAmplitude;
//            transform.position = new Vector3(basePos.x, basePos.y + y, basePos.z);
//        }

//        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
//    }

//    protected override void Interact()
//    {
//        TryPickup();
//    }

//    void TryPickup()
//    {
//        if (!playerNearby || pickedUp) return;
//        pickedUp = true;
//        StartCoroutine(PickupRoutine());
//    }

//    IEnumerator PickupRoutine()
//    {
//        enabled = false;

//        Collider2D col = GetComponent<Collider2D>();
//        if (col != null) col.enabled = false;

//        gameObject.layer = LayerMask.NameToLayer("Player");
//        foreach (Transform tr in GetComponentsInChildren<Transform>(true))
//            tr.gameObject.layer = LayerMask.NameToLayer("Player");

//        GameObject player = GameManager.Instance.playerNormal;
//        GameManager.Instance.SaveCheckpoint(transform.position);
//        Transform hand = player.transform.Find("PlayerVisual/HandPoint");
//        if (hand == null)
//        {
//            Debug.LogError("HandPoint missing");
//            yield break;
//        }

//        transform.SetParent(hand, false);
//        transform.localPosition = Vector3.zero;
//        transform.localRotation = Quaternion.identity;

//        player.GetComponent<PlayerController>()?.SetArmed();
//        GameManager.Instance.currentGun = gameObject;

//        yield return new WaitForSeconds(0.2f);

//        GameManager.Instance.StartBossSequence();
//    }

//    public void ConvertToHeld()
//    {
//        pickedUp = true;
//        enabled = false;

//        transform.localPosition = Vector3.zero;
//        transform.localRotation = Quaternion.identity;
//        transform.localScale = Vector3.one;

//        Rigidbody2D rb = GetComponent<Rigidbody2D>();
//        if (rb != null)
//        {
//            rb.linearVelocity = Vector2.zero;
//            rb.angularVelocity = 0f;
//            rb.bodyType = RigidbodyType2D.Kinematic;
//        }

//        Collider2D col = GetComponent<Collider2D>();
//        if (col != null) col.enabled = false;
//    }

//    protected override void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerNearby = true;
//            GameMessageManager.instance?.ShowMessage("Press E to pick up gun");
//        }
//    }

//    protected override void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//            playerNearby = false;
//    }
//}

using System.Collections;
using UnityEngine;

public class GunPickup : Interactable
{
    [Header("Float")]
    public float riseHeight = 1.5f;
    public float riseSpeed = 2f;
    public float floatAmplitude = 0.2f;
    public float floatSpeed = 2f;
    public float rotateSpeed = 60f;

    private Vector3 basePos;
    private bool raised;
    private bool pickedUp;
    private float t;

    private void Start()
    {
        basePos = transform.position;
    }

    private void Update()
    {
        if (pickedUp) return;

        if (!raised)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;

            if (transform.position.y >= basePos.y + riseHeight)
            {
                raised = true;
                basePos = transform.position;
            }
        }
        else
        {
            t += Time.deltaTime;
            float y = Mathf.Sin(t * floatSpeed) * floatAmplitude;
            transform.position = new Vector3(basePos.x, basePos.y + y, basePos.z);
        }

        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void Interact()
    {
        if (pickedUp) return;
        pickedUp = true;
        StartCoroutine(PickupRoutine());
    }

    public override string GetPromptText()
    {
        return "Press E to pick up gun";
    }

    private IEnumerator PickupRoutine()
    {
        enabled = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        gameObject.layer = LayerMask.NameToLayer("Player");

        foreach (Transform tr in GetComponentsInChildren<Transform>(true))
            tr.gameObject.layer = LayerMask.NameToLayer("Player");

        GameObject player = GameManager.Instance.playerNormal;
        GameManager.Instance.SaveCheckpoint(transform.position);

        Transform hand = player.transform.Find("PlayerVisual/HandPoint");

        if (hand == null)
        {
            Debug.LogError("HandPoint missing");
            yield break;
        }

        transform.SetParent(hand, false);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        player.GetComponent<PlayerController>()?.SetArmed();
        GameManager.Instance.currentGun = gameObject;

        yield return new WaitForSeconds(0.2f);

        GameManager.Instance.StartBossSequence();
    }

    public void ConvertToHeld()
    {
        pickedUp = true;
        enabled = false;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;
    }
}