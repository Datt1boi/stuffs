﻿using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class DestroyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	void OnCollisionEnter(Collision collision)
	{
        
        if (collision.gameObject.name.Contains("enemy"))
        {
			Destroy(collision.gameObject);
		}
	}

}
