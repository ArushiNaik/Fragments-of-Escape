using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShooter : MonoBehaviour
{
    private bool canShoot = true;
    [Header("Raycast")]
    public float range = 20f;
    public int damage = 1;

    [Header("Fire Point")]
    public Transform firePoint;

    [Header("Layers")]
    public LayerMask hitMask;

    [Header("Visual Bullet")]
    public GameObject tracerPrefab;
    public float tracerSpeed = 6f;

    private GameInputActions inputActions;
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
        inputActions = new GameInputActions();
        inputActions.player.Enable();
        inputActions.player.Fire.performed += ctx => Shoot();
    }

    void OnDestroy()
    {
        inputActions.player.Disable();
    }

    void Update()
    {
        AimAtMouse();
    }

    void AimAtMouse()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
    {
        if (!canShoot) return;
        if (firePoint == null) return;

        Vector3 mouse = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouse.z = 0f;

        Vector2 dir = (mouse - firePoint.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, dir, range, hitMask);

        Vector2 targetPoint;
        BossCombat bossHit = null;

        if (hit.collider != null)
        {
            targetPoint = hit.point;
            bossHit = hit.collider.GetComponentInParent<BossCombat>();
        }
        else
        {
            targetPoint = (Vector2)firePoint.position + dir * range;
        }

        float distance = Vector2.Distance(firePoint.position, targetPoint);
        float travelTime = distance / tracerSpeed;

        GameManager.Instance.PlayTracer(tracerPrefab, firePoint.position, targetPoint, tracerSpeed);

        if (bossHit != null)
            StartCoroutine(DelayedDamage(bossHit, damage, travelTime));
    }

    IEnumerator DelayedDamage(BossCombat boss, int dmg, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (boss != null)
            boss.TakeDamage(dmg);
    }
    public void StopShooting()
    {
        canShoot = false;
    }
}

// public class GunShooter : MonoBehaviour
// {
//     [Header("Raycast")]
//     public float range = 20f;
//     public int damage = 1;

//     [Header("Fire Point")]
//     public Transform firePoint;

//     [Header("Layers")]
//     public LayerMask hitMask;

//     [Header("Visual Bullet")]
//     public GameObject tracerPrefab; // assign in inspector
//     public float tracerSpeed = 6f;  // lower = slower

//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//             Shoot();
//     }

//     void Shoot()
//     {
//         if (firePoint == null) return;

//         Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         mouse.z = 0f;

//         Vector2 dir = (mouse - firePoint.position).normalized;

//         RaycastHit2D hit = Physics2D.Raycast(firePoint.position, dir, range, hitMask);

//         Vector2 targetPoint;
//         BossCombat bossHit = null;

//         if (hit.collider != null)
//         {
//             targetPoint = hit.point;

//             bossHit = hit.collider.GetComponentInParent<BossCombat>();
//         }
//         else
//         {
//             targetPoint = (Vector2)firePoint.position + dir * range;
//         }

//         float distance = Vector2.Distance(firePoint.position, targetPoint);
//         float travelTime = distance / tracerSpeed;

//         // 🔥 play visual bullet
//         GameManager.Instance.PlayTracer(tracerPrefab, firePoint.position, targetPoint, tracerSpeed);

//         // 🔥 DELAY DAMAGE to match visual impact
//         if (bossHit != null)
//         {
//             StartCoroutine(DelayedDamage(bossHit, damage, travelTime));
//         }
//     }
//     IEnumerator DelayedDamage(BossCombat boss, int dmg, float delay)
//     {
//         yield return new WaitForSeconds(delay);

//         if (boss != null)
//         {
//             boss.TakeDamage(dmg);
//         }
//     }


// }