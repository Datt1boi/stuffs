using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int health = 10;
	bool invulnerable = false;
	float time = 0;
	float flashTimer = 0;
	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("Health", health);
	}
	
	// Update is called once per frame
	void Update () {
		if(invulnerable){
			
			//flash
			flashTimer += Time.deltaTime;
			if(flashTimer < 0.1f){
				//set color slightly transparent
				Vector4 color = gameObject.GetComponent<SpriteRenderer>().color;
				color.w = 0.8f;
				gameObject.GetComponent<SpriteRenderer>().color = color;
			}else if (flashTimer >0.1f && flashTimer < 0.2f){
				Vector4 color = gameObject.GetComponent<SpriteRenderer>().color;
				color.w = 1;
				gameObject.GetComponent<SpriteRenderer>().color = color;
				
			}
			
			
			time += Time.deltaTime;
			if(time >= 2){
				invulnerable = false;
				time = 0;
			}
		}
		
		
		if (PlayerPrefs.GetInt("Health") <= 0) {
			//reload the scene if player health is equal to or less than 0
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene (scene.name);

		}

	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Baddie" && invulnerable == false) {
			Debug.Log (PlayerPrefs.GetInt ("Health"));
			
			PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 1);
			invulnerable = true;
			
		}
	}

}
