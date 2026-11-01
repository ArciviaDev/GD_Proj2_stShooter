using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HandgunFire : MonoBehaviour
{
    public AmmoCounts ammoCounts;
    
    [SerializeField] AudioSource gunFire;
    [SerializeField] private GameObject handgun;
    [SerializeField] private bool canFire = true;
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ammoCounts.CheckAmmoCount();
            
            if (canFire == true)
            {
                canFire = false;
                StartCoroutine(FiringGun());
            }
        }

        // Execute Firing FX + Firing Animation then pausing for a short amount of time before executing again
        IEnumerator FiringGun()
        {
            ammoCounts.AmmoCountDown();
            gunFire.Play();
            handgun.GetComponent<Animator>().Play("HandgunFire");
            yield return new WaitForSeconds(0.5f);
            handgun.GetComponent<Animator>().Play("New State");
            yield return new WaitForSeconds(0.1f);
            canFire = true;
        }
    }

    public void FireTrue()
    {
        canFire = true;
    }
}
