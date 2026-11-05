using UnityEngine;
using UnityEngine.InputSystem;

public class GrenadeThrow : MonoBehaviour
{
    [Header("Grenade Settings")]
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwForce = 12f;
    [SerializeField] private float upwardForce = 3f;

    [Header("Grenade Count")]
    [SerializeField] private GrenadeCounts grenadeCounts;

    void Update()
    {
        // Left-click to throw
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        // Make sure the prefab and throw point exist
        if (grenadePrefab == null || throwPoint == null)
            return;

        // Do not throw if grenade count is zero
        if (!grenadeCounts.UseGrenade())
            return;

        // Create the thrown grenade
        GameObject grenade = Instantiate(
            grenadePrefab,
            throwPoint.position,
            throwPoint.rotation
        );

        // Get its Rigidbody
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction =
                throwPoint.forward * throwForce +
                Vector3.up * upwardForce;

            rb.AddForce(direction, ForceMode.Impulse);
        }
    }
}