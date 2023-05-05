using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCount = 10;

    private int enemiesKilled = 0;

    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled >= enemyCount)
        {
            SceneManager.LoadScene("win screen");
        }
    }
}
