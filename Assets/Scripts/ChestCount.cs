using UnityEngine;
using TMPro;

public class ChestCount : MonoBehaviour
{
    public ObjectiveScript objectives;
    public GameObject ChestTextContainer;
    
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
            objectives.ObjectiveChange();
            ChestTextContainer.SetActive(false);
        }
    }

    public void CollectedChest()
    {
        currentChestCount++;
        UpdateChestCount();
    }

    public void UpdateChestCount()
    {
        CheckChestCount();
        ChestCountText.text = "Chest Collected: " + currentChestCount + "/3";
    }
}
