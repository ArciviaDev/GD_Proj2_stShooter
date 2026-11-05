
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwapping : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private GameObject handgun;
    [SerializeField] private GameObject grenade;

    [Header("Handgun Scripts")]
    [SerializeField] private GameObject GlobalObject;
    [SerializeField] private PlayerCasting playerCasting;

    [Header("Weapon UI")]
    [SerializeField] private GameObject handgunAmmoUI;
    [SerializeField] private GameObject grenadeCountUI;

    private bool hasHandgun = false;
    private bool hasGrenade = false;

    // 0 = No weapon
    // 1 = Handgun
    // 2 = Grenade
    private int selectedWeapon = 0;

    void Start()
    {
        UpdateWeapons();
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.qKey.wasPressedThisFrame)
        {
            SwapWeapon();
        }
    }

    void SwapWeapon()
    {
        // Both weapons must be collected to swap
        if (!hasHandgun || !hasGrenade)
            return;

        if (selectedWeapon == 1)
        {
            selectedWeapon = 2;
        }
        else
        {
            selectedWeapon = 1;
        }

        UpdateWeapons();
    }

    public void PickupHandgun()
    {
        hasHandgun = true;

        // Equip if player has no weapon
        if (selectedWeapon == 0)
        {
            selectedWeapon = 1;
        }

        UpdateWeapons();
    }

    public void PickupGrenade()
    {
        hasGrenade = true;

        // Equip if player has no weapon
        if (selectedWeapon == 0)
        {
            selectedWeapon = 2;
        }

        UpdateWeapons();
    }

    void UpdateWeapons()
    {
        bool handgunEquipped =
            hasHandgun && selectedWeapon == 1;

        bool grenadeEquipped =
            hasGrenade && selectedWeapon == 2;

        // Enable only the selected weapon
        handgun.SetActive(handgunEquipped);
        grenade.SetActive(grenadeEquipped);

        // Control handgun shooting
        GlobalObject.GetComponent<HandgunFire>().enabled =
            handgunEquipped;

        GlobalObject.SetActive(handgunEquipped);

        playerCasting.enabled = handgunEquipped;
        
        // Enable/disable weapon UI
        handgunAmmoUI.SetActive(handgunEquipped);
        grenadeCountUI.SetActive(grenadeEquipped);
    }
}
