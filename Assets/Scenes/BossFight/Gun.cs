using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public float range = 20f;
    public int damage = 1;

    [Header("Hit Layers")]
    public LayerMask hitMask; // set to Monster

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (firePoint == null) return;

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0f;

        Vector2 dir = (mouse - firePoint.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, dir, range, hitMask);

        Debug.DrawRay(firePoint.position, dir * range, Color.red, 0.2f);

        if (hit.collider != null)
        {
            BossCombat boss = hit.collider.GetComponentInParent<BossCombat>();

            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
        }
    }
}