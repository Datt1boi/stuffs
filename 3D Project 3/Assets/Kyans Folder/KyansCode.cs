using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyansCode : MonoBehaviour
{
    public string enemyTag = "Enemy";  // tag to assign to the enemy

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == enemyTag)
        {
            ScoreTextScript.enemyCount += 1;
            other.gameObject.tag = enemyTag; // assign the tag to the enemy
            Destroy(gameObject);
        }
    }
}