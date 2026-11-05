
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [Header("Explosion Settings")]
    [SerializeField] private float explosionDelay = 3f;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private int explosionDamage = 3;
    [SerializeField] private float explosionForce = 500f;

    [Header("Explosion Effects")]
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private AudioClip explosionSFX;

    void Start()
    {
        StartCoroutine(ExplosionTimer());
    }

    IEnumerator ExplosionTimer()
    {
        // Wait before exploding
        yield return new WaitForSeconds(explosionDelay);

        Explode();
    }

    void Explode()
    {
        // Find objects inside the explosion radius
        Collider[] colliders = Physics.OverlapSphere(
            transform.position,
            explosionRadius
        );

        // Prevent damaging the same enemy multiple times
        HashSet<EnemyManager> damagedEnemies =
            new HashSet<EnemyManager>();

        foreach (Collider hit in colliders)
        {
            // Check if the object is an enemy
            EnemyManager enemy =
                hit.GetComponentInParent<EnemyManager>();

            if (enemy != null && damagedEnemies.Add(enemy))
            {
                enemy.TakeDamage(explosionDamage);
            }

            // Apply explosion force to physics objects
            Rigidbody rb = hit.attachedRigidbody;

            if (rb != null)
            {
                rb.AddExplosionForce(
                    explosionForce,
                    transform.position,
                    explosionRadius
                );
            }
        }

        // Spawn explosion visual effect
        if (explosionVFX != null)
        {
            GameObject effect = Instantiate(
                explosionVFX,
                transform.position,
                Quaternion.identity
            );

            Destroy(effect, 3f);
        }

        // Play explosion sound
        if (explosionSFX != null)
        {
            AudioSource.PlayClipAtPoint(
                explosionSFX,
                transform.position
            );
        }

        // Remove thrown grenade
        Destroy(gameObject);
    }

    // Display explosion radius in Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            transform.position,
            explosionRadius
        );
    }
}
