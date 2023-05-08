using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCount = 10;
    public string enemyTag = "Enemy"; // add a public variable for the enemy tag

    private int enemiesKilled = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag)) // check if the other game object has the specified tag
        {
            EnemyKilled();
        }
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled >= enemyCount)
        {
            SceneManager.LoadScene("win screen");
        }
    }
}

