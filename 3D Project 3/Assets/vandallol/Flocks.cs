using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocks : MonoBehaviour
{
    public GameObject fishPrefab;
    public static int tankSize = 5;

    static int numFish = 10;
    public static GameObject[] allFish = new GameObject[numFish];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
