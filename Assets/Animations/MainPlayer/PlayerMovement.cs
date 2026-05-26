using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
[Header("Movement")]
    public float speed = 5f;
    public float runMultiplier = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isSprinting;
    private Animator anim;
    private GameInputActions inputActions;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        inputActions = new GameInputActions();
        inputActions.player.Enable();

        inputActions.player.move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        inputActions.player.move.canceled += ctx => movement = Vector2.zero;
        inputActions.player.Sprint.performed += ctx => isSprinting = true;
        inputActions.player.Sprint.canceled += ctx => isSprinting = false;
    }

    void OnDestroy()
    {
        inputActions.player.Disable();
    }

    void Update()
    {
        bool isWalking = movement.magnitude > 0.1f;
        anim.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            anim.SetFloat("input_x", movement.x);
            anim.SetFloat("input_y", movement.y);
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = isSprinting ? speed * runMultiplier : speed;
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
    //hello
}

// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     [Header("Movement")]
//     public float speed = 5f;
//     public float runMultiplier = 2f;

//     private Rigidbody2D rb;
//     private Vector2 movement;

//     [Header("Animation")]
//     private Animator anim;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//     }

//     void Update()
//     {
//         // Input
//         movement.x = Input.GetAxisRaw("Horizontal");
//         movement.y = Input.GetAxisRaw("Vertical");

//         // Normalize diagonal movement
//         movement = movement.normalized;

//         // Animation
//         bool isWalking = movement.magnitude > 0;

//         anim.SetBool("isWalking", isWalking);

//         if (isWalking)
//         {
//             anim.SetFloat("input_x", movement.x);
//             anim.SetFloat("input_y", movement.y);
//         }
//     }

//     void FixedUpdate()
//     {
//         float currentSpeed = speed;

//         // Sprint
//         if (Input.GetKey(KeyCode.LeftShift))
//         {
//             currentSpeed *= runMultiplier;
//         }

//         rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
//     }
// }