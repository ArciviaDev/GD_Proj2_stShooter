using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandgunFire : MonoBehaviour
{
    public AmmoCounts ammoCounts;
    public PlayerCasting playerCasting;

    [SerializeField] AudioSource gunFire;
    [SerializeField] AudioSource PlayerIsHit;
    
    [SerializeField] private GameObject handgun;
    [SerializeField] private bool canFire = true;
    
    [SerializeField] private GameObject muzzleFlashVFX;
    [SerializeField] private Transform muzzlePoint;

    void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            ammoCounts.CheckAmmoCount();

            if (canFire == true)
            {
                canFire = false;
                StartCoroutine(FiringGun());
            }
        }
    }

    IEnumerator FiringGun()
    {
        ammoCounts.AmmoCountDown();

        // Shoot a ray toward the enemy
        playerCasting.Shoot();

        // Spawn muzzle flash VFX
        GameObject flash = Instantiate(
            muzzleFlashVFX,
            muzzlePoint.position,
            muzzlePoint.rotation
        );

        // Remove VFX after a short time
        Destroy(flash, 0.2f);

        gunFire.Play();

        handgun.GetComponent<Animator>().Play("HandgunFire");

        yield return new WaitForSeconds(0.5f);

        handgun.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(0.1f);

        canFire = true;
    }
    
    public void PlayerHit()
    {
        PlayerIsHit.Play();
    }

    public void FireTrue()
    {
        canFire = true;
    }
}