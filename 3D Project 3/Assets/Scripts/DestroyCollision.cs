using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class DestroyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "GUN") {
			Destroy (collision.gameObject);
		}
	}
}
