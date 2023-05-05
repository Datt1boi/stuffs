using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour {


	public int health = 10;
    public Slider slider;
    float timer = 0f;

    void Start ()
    {
        slider.maxValue = health;
        slider.value = health;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (health <= 0)
        {
			//reload the level
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene (scene.name);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Hostile")
        {
			health -= 10;

		}
	}
}
