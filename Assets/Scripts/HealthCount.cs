using StarterAssets;
using UnityEngine;
using TMPro;

public class HealthCount : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeathScreen;
    public StarterAssetsInputs StarterAssetsInputs;
    
    [SerializeField] private TMP_Text HealthText;
    
    private int maxHealth = 3;
    [SerializeField] int currentHealth = 3;
    
    void Start()
    {
        UpdateHealthText();
    }

    public void TakenDamage()
    {
        currentHealth--;
        UpdateHealthText();
    }

    public void CheckHealthCount()
    {
        if (currentHealth < 1)
        {
            Player.SetActive(false);
            DeathScreen.SetActive(true);
            StarterAssetsInputs.UnlockCursor();
        }
    }

    public void Healing()
    {
        if (currentHealth == maxHealth)
        {
            return;
        }
        
        currentHealth += 1;
        UpdateHealthText();
    }
    
    void UpdateHealthText()
    {
        HealthText.text = "HP: " + currentHealth;
        CheckHealthCount();
    }
}
