using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishspeed : MonoBehaviour
{
    public float speed = -2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
