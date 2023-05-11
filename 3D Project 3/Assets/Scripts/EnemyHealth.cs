using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnCollision : MonoBehaviour
{
    public string destroyTag = "GUN"; // tag of the object that can destroy this object

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(destroyTag))
        {
            Destroy(gameObject);
        }
    }
}
