using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    [Header("Damage Flash")]
    [SerializeField] private Renderer enemyRenderer;
    [SerializeField] private Material whiteMaterial;
    [SerializeField] private float flashDuration = 0.2f;

    private Material originalMaterial;
    private Coroutine flashCoroutine;

    void Start()
    {
        currentHealth = maxHealth;

        // Save the enemy's original red material
        originalMaterial = enemyRenderer.sharedMaterial;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy Health: " + currentHealth);

        // Restart the flash when the enemy is hit
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashDamage());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashDamage()
    {
        // Change the enemy's material to white
        enemyRenderer.sharedMaterial = whiteMaterial;

        // Wait for a short time
        yield return new WaitForSeconds(flashDuration);

        // Change back to the original red material
        enemyRenderer.sharedMaterial = originalMaterial;

        flashCoroutine = null;
    }

    void Die()
    {
        Debug.Log("Enemy Died!");

        Destroy(gameObject);
    }
}