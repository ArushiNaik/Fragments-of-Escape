using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 1.5f;

    [Header("Movement")]
    [SerializeField] private float smoothSpeed = 8f;
    [SerializeField] private float stoppingDistance = 0.15f;

    private Vector2 moveDirection;
    private Vector2 currentVelocity;

    private bool isMoving = false;

    private Vector3 currentTarget;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 direction =
                ((Vector2)currentTarget - rb.position);

            float distance = direction.magnitude;

            // stop close to player
            if (distance <= stoppingDistance)
            {
                Stop();
                return;
            }

            direction.Normalize();

            // smooth turning
            moveDirection = Vector2.Lerp(
                moveDirection,
                direction,
                smoothSpeed * Time.fixedDeltaTime
            ).normalized;

            currentVelocity =
                moveDirection * moveSpeed;

            rb.MovePosition(
                rb.position +
                currentVelocity * Time.fixedDeltaTime
            );

            anim.SetBool("IsActive", true);
            anim.SetFloat("input_x", moveDirection.x);
            anim.SetFloat("input_y", moveDirection.y);
        }
        else
        {
            anim.SetBool("IsActive", false);
        }
    }

    public void MoveTowards(Vector3 target)
    {
        currentTarget = target;

        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;

        currentVelocity = Vector2.zero;
    }
}