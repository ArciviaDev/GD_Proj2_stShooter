using System;
using UnityEngine;

public class HealingAid : MonoBehaviour
{
    public HealthCount healthCount;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            healthCount.Healing();
            Destroy(gameObject);
        }
    }
}
