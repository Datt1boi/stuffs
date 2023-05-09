using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class DestroyCollision : MonoBehaviour
{
    public string enemyTag = "Enemy"; // set the tag for the enemy game object

    // Use this for initialization
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == enemyTag)
        {
            Destroy(gameObject);
        }
    }
}
