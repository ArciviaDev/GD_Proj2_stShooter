
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform treasureBox;
    public NavMeshAgent agent;

    [Header("Protection Zone")]
    public float protectionRadius = 15f;
    public float patrolRadius = 10f;

    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 7f;
    public float fleeSpeed = 5f;

    [Header("Shooting")]
    public float shootingRange = 10f;
    public float fireRate = 2f;
    public int damage = 1;

    private float nextFireTime;
    private bool treasureStolen = false;
    private bool allTreasuresCollected = false;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private HealthCount playerHealth;
    
    [Header("Shooting VFX")]
    [SerializeField] private GameObject muzzleFlashVFX;
    [SerializeField] private GameObject impactVFX;
    
    [Header("Shooting Accuracy")]
    [SerializeField] private float bulletSpread = 5f;
    
    [Header("Shooting SFX")]
    [SerializeField] private AudioSource gunshotSFX;

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        Patrol();
    }

    void Update()
    {
        if (player == null || agent == null || !agent.isOnNavMesh)
            return;

        if (treasureBox == null && !treasureStolen)
            return;

        float distance = Vector3.Distance(
            player.position, treasureBox.position
        );

        // All treasures collected: flee from player
        if (allTreasuresCollected)
        {
            Flee();
        }
        // Treasure stolen: chase player anywhere
        else if (treasureStolen)
        {
            Chase();
        }
        // Player inside protection zone
        else if (distance <= protectionRadius)
        {
            Chase();
        }
        // Player outside protection zone
        else
        {
            agent.speed = patrolSpeed;

            if (!agent.pathPending &&
                agent.remainingDistance <= 0.5f)
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;

        // Pick a random position around treasure box
        Vector3 randomPoint =
            treasureBox.position +
            Random.insideUnitSphere * patrolRadius;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(
            randomPoint, out hit, 3f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    void Chase()
    {
        float distanceToPlayer =
            Vector3.Distance(transform.position, player.position);

        agent.speed = chaseSpeed;

        if (distanceToPlayer > shootingRange)
        {
            // Chase the player
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            // Stop moving when close enough to shoot
            agent.isStopped = true;

            Shoot();
        }
    }

    
    void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            // Calculate direction toward the player
            Vector3 direction =
                (player.position - firePoint.position).normalized;

            // Add random bullet spread
            Quaternion randomSpread = Quaternion.Euler(
                Random.Range(-bulletSpread, bulletSpread),
                Random.Range(-bulletSpread, bulletSpread),
                0f
            );

            // Apply spread to the shooting direction
            direction = randomSpread * direction;
            
            // Play gunshot SFX
            if (gunshotSFX != null)
            {
                gunshotSFX.PlayOneShot(gunshotSFX.clip);
            }

            // Create muzzle flash VFX
            if (muzzleFlashVFX != null)
            {
                GameObject flash = Instantiate(
                    muzzleFlashVFX,
                    firePoint.position,
                    firePoint.rotation
                );

                Destroy(flash, 0.2f);
            }

            RaycastHit hit;

            // Shoot a ray toward the player
            if (Physics.Raycast(
                    firePoint.position,
                    direction,
                    out hit,
                    shootingRange))
            {
                Debug.Log("Enemy shot: " + hit.collider.name);

                // Create bullet impact VFX
                if (impactVFX != null)
                {
                    GameObject impact = Instantiate(
                        impactVFX,
                        hit.point,
                        Quaternion.LookRotation(hit.normal)
                    );

                    Destroy(impact, 2f);
                }

                // Check whether the raycast hit the player
                if (hit.collider.CompareTag("Player"))
                {
                    playerHealth.TakenDamage();

                    Debug.Log("Player took damage!");
                }
            }
        }
    }


    void Flee()
    {
        agent.speed = fleeSpeed;

        Vector3 direction =
            (transform.position - player.position).normalized;

        Vector3 fleePosition =
            transform.position + direction * 10f;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(
            fleePosition, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    public void TreasureStolen()
    {
        treasureStolen = true;
    }

    public void AllTreasuresCollected()
    {
        allTreasuresCollected = true;
    }
    
    // Seeing the protection zone for testing behavior
    private void OnDrawGizmosSelected()
    {
        if (treasureBox == null)
            return;

        // Draw protection zone in red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            treasureBox.position,
            protectionRadius
        );

        // Draw patrol zone in green
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(
            treasureBox.position,
            patrolRadius
        );
    }
}
