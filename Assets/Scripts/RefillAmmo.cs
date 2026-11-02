using System;
using UnityEngine;

public class RefillAmmo : MonoBehaviour
{
    public AmmoCounts ammoCounts;
    public GameObject GlobalObject;
    public HandgunFire handgun;

    public AudioSource refillFX;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GlobalObject.SetActive(true);
            handgun.FireTrue();
            ammoCounts.RefillAmmoCount();
            refillFX.Play();
        }
    }
}
