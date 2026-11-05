using UnityEngine;
using TMPro;

public class GrenadeCounts : MonoBehaviour
{
    [SerializeField] private TMP_Text grenadeText;

    private int grenadeCount = 0;

    void Start()
    {
        UpdateGrenadeText();
    }

    // Add one grenade when collected
    public void AddGrenade()
    {
        grenadeCount++;
        UpdateGrenadeText();
    }

    // Check and use one grenade
    public bool UseGrenade()
    {
        if (grenadeCount <= 0)
        {
            return false;
        }

        grenadeCount--;
        UpdateGrenadeText();

        return true;
    }

    void UpdateGrenadeText()
    {
        grenadeText.text = "Grenades: " + grenadeCount;
    }
}