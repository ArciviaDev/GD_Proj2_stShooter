using UnityEngine;

public class TreasureCollection : MonoBehaviour
{
    public ChestCount chestCount;
    
    // The guard protecting this treasure
    public EnemyAI[] guards;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touches the treasure
        if (other.CompareTag("Player"))
        {
            Debug.Log("Treasure Collected!");
            chestCount.CollectedChest();

            // Tell all guards protecting this treasure
            // to chase the player permanently
            foreach (EnemyAI guard in guards)
            {
                if (guard != null)
                {
                    guard.TreasureStolen();
                }
            }

            // Remove the treasure from the scene
            Destroy(gameObject);
        }
    }
}