using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float runMultiplier = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isSprinting;
    private Animator anim;
    private GameInputActions inputActions;
    private bool canMove = true;

    public Transform handTransform;

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
        if (!canMove)
        {
            movement = Vector2.zero;
            anim.SetBool("isWalking", false);
            return;
        }

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
        if (!canMove)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float currentSpeed = isSprinting ? speed * runMultiplier : speed;
        rb.linearVelocity = movement * currentSpeed;
    }

    public void SetArmed()
    {
        if (anim == null) anim = GetComponent<Animator>();
        if (anim != null) anim.SetBool("isArmed", true);
    }

    public void EnableControl() { canMove = true; }
    public void DisableControl() { canMove = false; }
}


// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     [Header("Movement")]
//     public float speed = 5f;
//     public float runMultiplier = 2f;

//     private Rigidbody2D rb;
//     private Vector2 movement;

//     [Header("Animation")]
//     private Animator anim;

//     public Transform handTransform;
//     private bool canMove = true;

//     void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//     }

//     void Update()
//     {
//         if (!canMove)
//         {
//             movement = Vector2.zero;
//             anim.SetBool("isWalking", false);
//             return;
//         }

//         movement.x = Input.GetAxisRaw("Horizontal");
//         movement.y = Input.GetAxisRaw("Vertical");
//         movement = movement.normalized;

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
//         if (!canMove)
//         {
//             rb.linearVelocity = Vector2.zero;
//             return;
//         }

//         float currentSpeed = speed;

//         if (Input.GetKey(KeyCode.LeftShift))
//             currentSpeed *= runMultiplier;

//         rb.linearVelocity = movement * currentSpeed;
//     }

//     public void SetArmed()
//     {
//         if (anim == null)
//             anim = GetComponent<Animator>();

//         if (anim != null)
//             anim.SetBool("isArmed", true);
//     }
//     public void EnableControl()
//     {
//         canMove = true;
//     }

//     public void DisableControl()
//     {
//         canMove = false;
//     }
// }