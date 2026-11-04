using System;
using UnityEngine;

public class RefillAmmo : MonoBehaviour
{
    public AmmoCounts ammoCounts;
    public GameObject GlobalObject;
    public HandgunFire handgun;

    public AudioSource refillFX;

    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void AllChestsAquired()
    {
        gameObject.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ammoCounts.CheckAmmoCount();
            GlobalObject.SetActive(true);
            handgun.FireTrue();
            ammoCounts.RefillAmmoCount();
            refillFX.Play();
        }
    }
}
