using UnityEngine;

public class PickUpGrenade : MonoBehaviour
{
    [SerializeField] private WeaponSwapping weaponSwitching;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weaponSwitching.PickupGrenade();

            Destroy(gameObject);
        }
    }
}
