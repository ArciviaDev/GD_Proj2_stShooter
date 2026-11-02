using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 40f;

    private Vector3 targetPosition;

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        // Move bullet toward its destination
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // Destroy bullet when it reaches destination
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}