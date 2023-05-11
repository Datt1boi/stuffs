using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KyansCode : MonoBehaviour
{
    public int targetCount = 10; // the number of enemies needed to trigger the scene change
    private int currentCount = 0; // the current count of destroyed enemies

    public void EnemyDestroyed()
    {
        currentCount++;

        // check if the target count has been reached
        if (currentCount >= targetCount)
        {
            // load the specified scene
            SceneManager.LoadScene("Win Screen");
        }
    }
}
