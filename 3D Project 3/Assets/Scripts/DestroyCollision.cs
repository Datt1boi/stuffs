using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class DestroyCollision : MonoBehaviour {
	public int endgame = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (endgame <= 0)
		{
			//reload the level
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}


	void OnCollisionEnter(Collision collision)
	{
        
        if (collision.gameObject.name.Contains("GUN"))
        {
			
			endgame -= 1;
			Destroy(gameObject);
		}
    }

}
