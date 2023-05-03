using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // The enemy prefab to be spawned
    public float spawnDelay = 1f;    // The delay between enemy spawns
    public int maxEnemies = 10;      // The maximum number of enemies that can be spawned
    public float vulnerableDelay = 0.5f; // The delay before the enemy becomes vulnerable to collisions

    private int spawnedEnemies = 0;  // The number of enemies spawned so far
    private float timeSinceSpawn = 0f;  // The time since the last enemy spawn

    void Update()
    {
        // If there are still enemies to be spawned and the spawn delay has passed
        if (spawnedEnemies < maxEnemies && Time.time - timeSinceSpawn > spawnDelay)
        {
            // Spawn an enemy
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnedEnemies++;
            timeSinceSpawn = Time.time;

            // Make the enemy invulnerable for a short time after it spawns
            StartCoroutine(MakeEnemyVulnerable(newEnemy));
        }
    }

    IEnumerator MakeEnemyVulnerable(GameObject enemy)
    {
        // Wait for the specified delay before making the enemy vulnerable
        yield return new WaitForSeconds(vulnerableDelay);

        // Enable the enemy's collider
        enemy.GetComponent<Collider>().enabled = true;
    }
}
