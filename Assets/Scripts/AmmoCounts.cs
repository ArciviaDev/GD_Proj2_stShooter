using UnityEngine;
using TMPro;

public class AmmoCounts : MonoBehaviour
{
    public GameObject GlobalObject;
    
    [SerializeField] private TMP_Text ammoText;

    private int maxAmmo = 6;
    private int currentAmmo = 0;
    
    void Start()
    {
        UpdateAmmoText();
    }

    public void AmmoCountDown()
    {
        currentAmmo--;
        UpdateAmmoText();
    }

    public void CheckAmmoCount()
    {
        if (currentAmmo == maxAmmo)
        {
            return;
        }
        
        if (currentAmmo < 1)
        {
            GlobalObject.SetActive(false);
        }
    }

    public void RefillAmmoCount()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }
    
    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + currentAmmo + "/6";
    }
}
