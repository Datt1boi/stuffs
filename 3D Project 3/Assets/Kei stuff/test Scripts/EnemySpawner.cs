using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // The enemy prefab to be spawned
    public float spawnDelay = 1f;    // The delay between enemy spawns
    public int maxEnemies = 10;      // The maximum number of enemies that can be spawned

    private int spawnedEnemies = 0;  // The number of enemies spawned so far
    private float timeSinceSpawn = 0f;  // The time since the last enemy spawn

    void Update()
    {
        // If there are still enemies to be spawned and the spawn delay has passed
        if (spawnedEnemies < maxEnemies && Time.time - timeSinceSpawn > spawnDelay)
        {
            // Spawn an enemy
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnedEnemies++;
            timeSinceSpawn = Time.time;
        }
    }
}
