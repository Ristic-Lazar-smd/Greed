using UnityEngine;

public class placeholderAttackTracking : MonoBehaviour
{
    public Reference reference;

    public Transform player; // Reference to the player's transform
    public Transform enemyParent; // Reference to the enemy parent's transform
    public float maxDistanceFromEnemy = 2f; // Maximum distance the hitbox can move from the enemy

    void Start()
    {
        player = reference.player.transform;
    }


    void Update()
    {
        if (player == null || enemyParent == null)
        {
            Debug.LogWarning("Player or Enemy Parent reference is missing!");
            return;
        }

        // Calculate direction to the player
        Vector2 directionToPlayer = (player.position - enemyParent.position).normalized;

        // Rotate the hitbox to face the player
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Position the hitbox towards the player but clamp it within maxDistanceFromEnemy
        Vector2 targetPosition = (Vector2)enemyParent.position + directionToPlayer * maxDistanceFromEnemy;
        transform.position = targetPosition;
    }
}
