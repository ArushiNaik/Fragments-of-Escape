using UnityEngine;

public class FriendController : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private Transform player;

    [Header("Follow Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float followDistance = 1.5f;

    private bool isFollowing = false;

    private Animator anim;
    private SpriteRenderer sprite;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isFollowing || player == null)
            return;

        FollowPlayer();
    }

    public void SetFree()
    {
        Debug.Log("Friend is now following player");

        isFollowing = true;
    }

    private void FollowPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // Stop when close enough
        if (distance <= followDistance)
        {
            if (anim != null)
                anim.SetBool("isWalking", false);

            return;
        }

        // Move toward player
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );

        // Walking animation
        if (anim != null)
            anim.SetBool("isWalking", true);

        // Flip sprite
        if (sprite != null)
        {
            sprite.flipX = player.position.x < transform.position.x;
        }
    }
}