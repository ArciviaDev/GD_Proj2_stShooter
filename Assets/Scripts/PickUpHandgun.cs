using System;
using UnityEngine;

public class PickUpHandgun : MonoBehaviour
{
    public ActiveGun ActiveGun;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ActiveGun.PickedUpGun();
            Destroy(gameObject);
        }
    }
}
