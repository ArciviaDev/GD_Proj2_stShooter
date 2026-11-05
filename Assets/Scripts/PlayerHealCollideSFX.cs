using UnityEngine;

public class PlayerHealCollideSFX : MonoBehaviour
{
    public AudioSource Healing;

    public void PlaySFX()
    {
        Healing.Play();
    }
}
