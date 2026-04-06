using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float runMultiplier = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Animation")]
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize diagonal movement
        movement = movement.normalized;

        // Animation
        bool isWalking = movement.magnitude > 0;

        anim.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            anim.SetFloat("input_x", movement.x);
            anim.SetFloat("input_y", movement.y);
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = speed;

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= runMultiplier;
        }

        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}