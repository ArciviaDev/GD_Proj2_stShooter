using UnityEngine;
using TMPro;

public class ChestCount : MonoBehaviour
{
    public ObjectiveScript objectives;
    public GameObject ChestTextContainer;
    public EnemyAI[] EnemyAI;
    public RefillAmmo[] refillAmmo;
    public PickUpGrenade[] pickUpGrenade;
    public GameObject enemiesKillCount;
    
    public PlayerChestCollideSFX playerChestCollideSFX;
    
    [SerializeField] private TMP_Text ChestCountText;
    
    private int currentChestCount = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateChestCount();
    }

    public void CheckChestCount()
    {
        if (currentChestCount >= 3)
        {
            foreach (EnemyAI enemy in EnemyAI)
            {
                if (enemy != null)
                {
                    enemy.AllTreasuresCollected();
                }
            }
            foreach (RefillAmmo refill in refillAmmo)
            {
                refill.AllChestsAquired();
            }
            
            foreach (PickUpGrenade grenadeCount in pickUpGrenade)
            {
                grenadeCount.AllChestsAquired();
            }

            objectives.ObjectiveChange();
            ChestTextContainer.SetActive(false);
            enemiesKillCount.SetActive(true);
        }
    }

    public void CollectedChest()
    {
        currentChestCount++;
        playerChestCollideSFX.PlaySFX();
        UpdateChestCount();
    }

    public void UpdateChestCount()
    {
        CheckChestCount();
        ChestCountText.text = "Chest Collected: " + currentChestCount + "/3";
    }
}
