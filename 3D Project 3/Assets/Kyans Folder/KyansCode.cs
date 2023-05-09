using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KyansCode : MonoBehaviour
{
    public string enemyTag = "Enemy";  // tag to assign to the enemy
    public int targetCount = 10;  // the number of enemies needed to trigger the scene change

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == enemyTag)
        {
            ScoreTextScript.enemyCount += 1;
            other.gameObject.tag = enemyTag; // assign the tag to the enemy

            if (ScoreTextScript.enemyCount >= targetCount)
            {
                SceneManager.LoadScene("win screen");
            }

            Destroy(gameObject);
        }
    }
}