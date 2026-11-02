using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceFromTarget;
    [SerializeField] private float toTarget;

    [SerializeField] private float shootingRange = 20f;
    [SerializeField] private int damage = 1;

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

            EnemyManager enemy = hit.collider.GetComponentInParent<EnemyManager>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}