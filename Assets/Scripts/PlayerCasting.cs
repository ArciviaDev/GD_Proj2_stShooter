using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceFromTarget;
    [SerializeField] private float toTarget;

    [SerializeField] private float shootingRange = 20f;
    [SerializeField] private int damage = 1;

    // Bullet impact VFX
    [SerializeField] private GameObject impactVFX;

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,
                transform.TransformDirection(Vector3.forward),
                out hit, shootingRange))
        {
            distanceFromTarget = hit.distance;
            toTarget = hit.distance;

            Debug.Log("Hit: " + hit.collider.name);

            // Spawn bullet impact VFX
            GameObject impact = Instantiate(
                impactVFX,
                hit.point,
                Quaternion.LookRotation(hit.normal)
            );

            // Remove impact VFX after 2 seconds
            Destroy(impact, 2f);

            EnemyManager enemy =
                hit.collider.GetComponentInParent<EnemyManager>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}