using UnityEngine;

public class PickUpHandgun : MonoBehaviour
{
    [SerializeField] private WeaponSwapping weaponSwitching;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weaponSwitching.PickupHandgun();

            Destroy(gameObject);
        }
    }
}