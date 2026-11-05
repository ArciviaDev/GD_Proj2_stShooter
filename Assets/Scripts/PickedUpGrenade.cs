using UnityEngine;

public class PickUpGrenade : MonoBehaviour
{
    [SerializeField] private WeaponSwapping weaponSwitching;
    [SerializeField] private GrenadeCounts grenadeCounts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Unlock the grenade weapon
            weaponSwitching.PickupGrenade();

            // Add one grenade to inventory
            grenadeCounts.AddGrenade();

            // Remove the collected grenade
            Destroy(gameObject);
        }
    }
}