using UnityEngine;
using TMPro;

public class HealthCount : MonoBehaviour
{
    public GameObject Player;
    
    [SerializeField] private TMP_Text HealthText;
    
    private int maxHealth = 3;
    private int currentHealth = 3;
    
    void Start()
    {
        UpdateHealthText();
    }

    void Update()
    {
        CheckHealthCount();
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
        }
    }

    public void Healing()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }
    
    void UpdateHealthText()
    {
        HealthText.text = "HP: " + currentHealth;
    }
}
