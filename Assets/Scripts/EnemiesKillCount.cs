using StarterAssets;
using UnityEngine;
using TMPro;

public class EnemiesKillCount : MonoBehaviour
{
    public GameObject VictoryScreen;
    public GameObject Player;
    public StarterAssetsInputs starterAssetsInputs;
    
    
    [SerializeField] private TMP_Text KillCountText;
    
    private int currentKillCount = 0;
    private int MaxKillCount = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateKillCount();
    }

    public void EnemyKilled()
    {
        currentKillCount++;
        UpdateKillCount();
    }

    public void CheckKillCount()
    {
        if (currentKillCount >= MaxKillCount)
        {
            Player.SetActive(false);
            VictoryScreen.SetActive(true);
            starterAssetsInputs.UnlockCursor();
        }
    }

    // Update is called once per frame
    public void UpdateKillCount()
   {
       CheckKillCount();
       KillCountText.text = "Enemies Killed: " + currentKillCount + "/5";
   } 
}
