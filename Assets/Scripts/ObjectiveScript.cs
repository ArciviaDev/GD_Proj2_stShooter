using UnityEngine;
using TMPro;

public class ObjectiveScript : MonoBehaviour
{
    
    [SerializeField] private TMP_Text ObjectiveText;
    
    void Start()
    {
        initialObjective();
    }

    public void ObjectiveChange()
    {
        ObjectiveText.text = "Objective: Look for ammo boxes and grenades to kill all remaining Enemies";
    }
    
    void initialObjective()
    {
        ObjectiveText.text = "Objective: Collect All Tressure Chests, Avoid Enemies, And find a Gun";
    }
}
