using System;
using UnityEngine;

public class PlayerChestCollideSFX : MonoBehaviour
{
    public AudioSource TreasureCollected;

    public void PlaySFX()
    {
        TreasureCollected.Play();
    }
}
