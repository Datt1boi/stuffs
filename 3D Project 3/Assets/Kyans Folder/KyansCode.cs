using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyansCode : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        ScoreTextScript.enemyCount += 1;
        Destroy(gameObject);
    }
}
