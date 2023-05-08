using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using JetBrains.Annotations;


public class DestroyCollision : MonoBehaviour
{
    public int enemiesToKill = 10; // set the number of enemies to kill to move to the next scene
    private int enemiesKilled = 0; // track the number of enemies killed
    public string enemyTag = "Enemy"; // set the tag for the enemy game object

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if the required number of enemies have been killed
        if (enemiesKilled >= enemiesToKill)
        {
            // load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemiesKilled++; // increment the enemies killed counter
            Destroy(gameObject);
        }
    }
}
